using System.Web.Mvc;

namespace LearnWords.Controllers
{
    public class GameController : Controller
    {
        // GET: GameController
        public ActionResult Index()
        {
            return View();
        }
    }
}