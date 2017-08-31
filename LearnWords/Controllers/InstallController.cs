using System.Web.Mvc;

namespace LearnWords.Controllers
{
    [AllowAnonymous]
    public class InstallController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}