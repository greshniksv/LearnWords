using System.Web.Mvc;

namespace LearnWords.Controllers
{
    [Authorize]
    public class WordsController : Controller
    {
        // GET: Words
        public ActionResult Index()
        {
            return View();
        }
    }
}