using System.Web.Mvc;

namespace LearnWords.Controllers
{
    public class WordsController : Controller
    {
        // GET: Words
        public ActionResult Index()
        {
            return View();
        }
    }
}