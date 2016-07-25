using System.Configuration;
using System.Web.Mvc;

namespace Client.Web.Controllers
{
    public class HomeController: Controller
    {
        public ActionResult Index()
        {
            var url = ConfigurationManager.AppSettings["ApiUrl"];

            return View(model: url);
        }
    }
}