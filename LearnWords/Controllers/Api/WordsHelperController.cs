using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Results;
using LearnWords.Contexts;
using LearnWords.Extensions;
using LearnWords.Models;
using LearnWords.Services;

namespace LearnWords.Controllers.Api
{
    public class WordsHelperController : System.Web.Http.ApiController
    {
        [System.Web.Http.HttpGet]
        public JsonResult<JsonResponse> CheckWord(string word)
        {
            WordsService service = new WordsService();
            var res = service.Exist(word);
            return res ? Json(new JsonResponse(true)) : Json(new JsonResponse(false, "Word not found"));
        }

        [System.Web.Http.HttpGet]
        public JsonResult<List<Word>> GetList()
        {
            var userId = HttpContext.Current.UserId();
            using (var db = new DBContext())
            {
                var user = db.Users.FirstOrDefault(x => x.UserId == userId);

                if (user != null)
                {
                    return Json(user.UserWords.Select(x => new Word(x)).ToList());
                }
            }
            return Json(new List<Word>());
        }

        [System.Web.Http.HttpPost]
        public JsonResult<JsonResponse> Add(string word)
        {
            var userId = HttpContext.Current.UserId();
            using (var db = new DBContext())
            {
                var user = db.Users.FirstOrDefault(x => x.UserId == userId);
                if (user != null)
                {
                    user.UserWords.Add(new UserWord { Word = word, User = user });
                    db.SaveChanges();
                    return Json(new JsonResponse(true));
                }
            }
            return Json(new JsonResponse(false, "User not found"));
        }

        [System.Web.Http.HttpPost]
        public JsonResult<JsonResponse> Edit(Guid id, string word)
        {
            var userId = HttpContext.Current.UserId();
            using (var db = new DBContext())
            {
                var user = db.Users.FirstOrDefault(x => x.UserId == userId);
                var wordItem = user?.UserWords.FirstOrDefault(x => x.UserWordId == id);
                if (wordItem != null)
                {
                    wordItem.Word = word;
                    db.SaveChanges();
                    return Json(new JsonResponse(true));
                }
            }
            return Json(new JsonResponse(false, "User or word not found"));
        }

        [System.Web.Http.HttpPost]
        public JsonResult<JsonResponse> Delete(Guid id)
        {
            var userId = HttpContext.Current.UserId();
            using (var db = new DBContext())
            {
                var user = db.Users.FirstOrDefault(x => x.UserId == userId);
                if (user != null)
                {
                    user.UserWords.RemoveAll(x=>x.UserWordId == id);
                    db.SaveChanges();
                    return Json(new JsonResponse(true));
                }
            }
            return Json(new JsonResponse(false, "User not found"));
        }
    }
}