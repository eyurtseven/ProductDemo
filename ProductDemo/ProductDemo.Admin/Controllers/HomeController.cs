using System.Web.Mvc;

namespace ProductDemo.Admin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        } 
    }
}