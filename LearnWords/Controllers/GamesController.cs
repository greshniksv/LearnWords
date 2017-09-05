using System.Web.Mvc;

namespace LearnWords.Controllers
{
    public class GamesController : Controller
    {
        // GET: Game
        public ActionResult Index()
        {
            return View();
        }
    }
}