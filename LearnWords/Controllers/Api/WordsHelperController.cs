using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using LearnWords.Contexts;
using LearnWords.Extensions;
using LearnWords.Models.Api;
using LearnWords.Models.Db;
using LearnWords.Services;

namespace LearnWords.Controllers.Api
{
    public class WordsHelperController : System.Web.Http.ApiController
    {
        [HttpGet]
        public JsonResult<JsonResponse> CheckWord(string word)
        {
            WordsService service = new WordsService();
            var res = service.Exist(word);
            return res ? Json(new JsonResponse(true)) : Json(new JsonResponse(false, "Word not found"));
        }

        [HttpGet]
        public JsonResult<List<Word>> GetList()
        {
            var userId = HttpContext.Current.UserId();
            using (var db = new DBContext())
            {
                var user = db.Users.FirstOrDefault(x => x.UserId == userId);

                if (user != null)
                {
                    return
                        Json(user.Dictionaries.First().UserWords.
                            OrderBy(x => x.Word).Select(x => new Word(x)).ToList());
                }
            }
            return Json(new List<Word>());
        }

        [HttpPost]
        public JsonResult<JsonResponse> Add(Word word)
        {
            if (string.IsNullOrEmpty(word.Description) || string.IsNullOrEmpty(word.Value))
            {
                return Json(new JsonResponse(false, "Word can't be null empty"));
            }

            var userId = HttpContext.Current.UserId();
            using (var db = new DBContext())
            {
                var user = db.Users.FirstOrDefault(x => x.UserId == userId);
                if (user != null)
                {
                    user.Dictionaries.First().UserWords.Add(new UserWord
                    {
                        Word = word.Value,
                        Description = word.Description,
                        User = user
                    });
                    db.SaveChanges();
                    return Json(new JsonResponse(true));
                }
            }
            return Json(new JsonResponse(false, "User not found"));
        }

        [HttpPost]
        public JsonResult<JsonResponse> Edit(Word obj)
        {
            var userId = HttpContext.Current.UserId();
            using (var db = new DBContext())
            {
                var user = db.Users.FirstOrDefault(x => x.UserId == userId);
                var wordItem = user?.Dictionaries.First().UserWords.FirstOrDefault(x => x.UserWordId == obj.Id);
                if (wordItem != null)
                {
                    wordItem.Word = obj.Value;
                    wordItem.Description = obj.Description;
                    wordItem.Remember = 0;
                    db.SaveChanges();
                    return Json(new JsonResponse(true));
                }
            }
            return Json(new JsonResponse(false, "User or word not found"));
        }

        [HttpPost]
        public JsonResult<JsonResponse> Delete([FromBody]Guid id)
        {
            var userId = HttpContext.Current.UserId();
            using (var db = new DBContext())
            {
                var word = db.UserWords.FirstOrDefault(x => x.UserId == userId && x.UserWordId == id);
                if (word != null)
                {
                    db.UserWords.Remove(word);
                    db.SaveChanges();
                    return Json(new JsonResponse(true));
                }
            }
            return Json(new JsonResponse(false, "User not found"));
        }
    }
}