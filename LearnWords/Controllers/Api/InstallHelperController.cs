using System.Web.Http.Results;
using LearnWords.Models;
using LearnWords.Services;

namespace LearnWords.Controllers.Api
{
    public class InstallHelperController : System.Web.Http.ApiController
    {
        [System.Web.Http.HttpPost]
        public JsonResult<JsonResponse> CheckWord(string word)
        {
            WordsService service = new WordsService();
            var res = service.Exist(word);
            return res ? Json(new JsonResponse(true)) : Json(new JsonResponse(false, "Word not found"));
        }
    }
}