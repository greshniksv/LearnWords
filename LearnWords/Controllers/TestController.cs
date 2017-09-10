using System.Collections.Generic;
using System.Web.Mvc;
using LearnWords.Contexts;
using LearnWords.Models;
using LearnWords.Models.Db;

namespace LearnWords.Controllers
{
    [AllowAnonymous]
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            using (var db = new DBContext())
            {
                var user = new User()
                {
                    Login = "admin",
                    Password = "admin",
                    Email = "admin@asd.com",
                    FullName = "admin",
                    Dictionaries = new List<Dictionary>()
                };

                var dict = new Dictionary()
                {
                    Name = "Eng",
                    UserWords = new List<UserWord>()
                };
                user.Dictionaries.Add(dict);

                dict.UserWords.Add(new UserWord()
                {
                    RusWord = "Стол",
                    Word = "Table",
                    Remember = 0
                });

                dict.UserWords.Add(new UserWord()
                {
                    RusWord = "Телефон",
                    Word = "Phone",
                    Remember = 0
                });

                dict.UserWords.Add(new UserWord()
                {
                    RusWord = "Монитор",
                    Word = "Monitor",
                    Remember = 0
                });
                db.Users.Add(user);
                db.SaveChanges();
            }

            return View();
        }
    }
}