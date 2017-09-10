using System;
using System.Web.Mvc;
using LearnWords.Authentication;
using LearnWords.Contexts;
using LearnWords.Models;
using Microsoft.Practices.Unity;

namespace LearnWords.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Authorize(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                if (!(string.IsNullOrEmpty(model.Login) && string.IsNullOrEmpty(model.Password)))
                {
                    var auth = MvcApplication.Unity.Resolve<IAuthentication>();
                    auth.HttpContext = System.Web.HttpContext.Current;
                    var user = auth.Login(model.Login, model.Password);

                    if (user == null)
                    {
                        ViewBag.Error = "Логин или пароль не верны";
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }

            return View("index", model);
        }

        [AllowAnonymous]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                if (!(string.IsNullOrEmpty(model.Login) && string.IsNullOrEmpty(model.Password)))
                {
                    try
                    {
                        using (var db = new DBContext())
                        {
                            db.Users.Add(new User()
                            {
                                Login = model.Login,
                                Email = model.Email,
                                Password = model.Password
                            });
                            db.SaveChanges();
                        }

                        ViewBag.Error = "Пользователь создался успешно";
                    }
                    catch (Exception)
                    {
                        ViewBag.Error = "Ошибка создания пользователя";
                    }
                }
            }

            return View("index");
        }

        [AllowAnonymous]
        public ActionResult LogOut()
        {
            var auth = MvcApplication.Unity.Resolve<IAuthentication>();
            auth.HttpContext = System.Web.HttpContext.Current;
            auth.LogOut();

            return RedirectToAction("Index", "Login");
        }

    }
}