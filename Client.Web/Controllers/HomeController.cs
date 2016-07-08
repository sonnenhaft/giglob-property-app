using System.Web.Mvc;

namespace Client.Web.Controllers
{
    public class HomeController: Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}