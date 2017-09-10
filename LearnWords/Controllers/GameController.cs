using System;
using System.Web.Mvc;
using LearnWords.Games;

namespace LearnWords.Controllers
{
    [Authorize]
    public class GameController : Controller
    {
        // GET: GameController
        public ActionResult Index(Guid id)
        {
            if (GamesHelper.Get(id) != null)
            {
                return View();
            }
            return View("Error");
        }

        public ActionResult List()
        {
            return View();
        }
    }
}