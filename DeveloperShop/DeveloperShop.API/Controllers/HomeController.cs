using System.Web.Mvc;

namespace DeveloperShop.API.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View("index.html");
        }
    }
}
