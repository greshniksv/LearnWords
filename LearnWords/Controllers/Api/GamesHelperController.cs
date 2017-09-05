using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using LearnWords.Contexts;
using LearnWords.Extensions;
using LearnWords.Models.Db;

namespace LearnWords.Controllers.Api
{
    public class GamesHelperController : ApiController
    {
        [System.Web.Http.HttpGet]
        public JsonResult<List<Word>> GetList()
        {
            var userId = HttpContext.Current.UserId();
            using (var db = new DBContext())
            {
                var user = db.Users.FirstOrDefault(x => x.UserId == userId);

                if (user != null)
                {
                    return Json(user.UserWords.OrderBy(x => x.Word).Select(x => new Word(x)).ToList());
                }
            }
            return Json(new List<Word>());
        }
    }
}