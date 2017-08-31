using System;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using LearnWords.Contexts;
using LearnWords.Exceptions.Authentication;
using LearnWords.Models;

namespace LearnWords.Authentication
{
    public class CustomAuthentication : IAuthentication
    {
        private const string CookieName = "__AUTH_COOKIE";

        public HttpContext HttpContext { get; set; }


        public User Login(string userName, string password)
        {
            using (var dbContext = new DBContext())
            {
                var users = dbContext.Users.Where(x => x.Login == userName).ToList();
                if (users.Count > 1)
                {
                    throw new Exception("Error. Founded duplicate user name!");
                }
                if (!users.Any())
                {
                    return null;
                }
                if (users[0].Password == password)
                {
                    CreateCookie(users[0].UserId.ToString());
                }
                return users[0];
            }
        }

        private void CreateCookie(string userId)
        {
            var ticket = new FormsAuthenticationTicket(
                  1,
                  userId,
                  DateTime.Now,
                  DateTime.Now.Add(FormsAuthentication.Timeout),
                  false,
                  string.Empty,
                  FormsAuthentication.FormsCookiePath);

            // Encrypt the ticket.
            var encTicket = FormsAuthentication.Encrypt(ticket);

            // Create the cookie.
            var authCookie = new HttpCookie(CookieName)
            {
                Value = encTicket,
                Expires = DateTime.Now.Add(FormsAuthentication.Timeout)
            };

            HttpContext.Response.Cookies.Set(authCookie);
        }

        public void LogOut()
        {
            var httpCookie = HttpContext.Response.Cookies[CookieName];
            if (httpCookie != null)
            {
                httpCookie.Value = string.Empty;
            }
        }

        private IPrincipal _currentUser;

        public IPrincipal CurrentUser
        {
            get
            {
                if (_currentUser == null)
                {
                    try
                    {
                        HttpCookie authCookie = HttpContext.Request.Cookies.Get(CookieName);
                        if (!string.IsNullOrEmpty(authCookie?.Value))
                        {
                            var ticket = FormsAuthentication.Decrypt(authCookie.Value);
                            if (ticket == null)
                            {
                                throw new CookieDecryptException($"Cookie value: {authCookie.Value}");
                            }
                            _currentUser = new UserProvider(ticket.Name);
                        }
                        else
                        {
                            _currentUser = null;
                        }
                    }
                    catch (UserNotFoundException)
                    {
                        _currentUser = null;
                    }
                    catch (System.Exception)
                    {
                        _currentUser = null;
                    }
                }

                if (_currentUser == null)
                {
                    LogOut();
                }
                return _currentUser;
            }
        }
    }
}