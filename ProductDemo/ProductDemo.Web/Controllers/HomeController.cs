using System.Linq;
using System.Web.Mvc;
using ProductDemo.Core.Infrastructure;

namespace ProductDemo.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public HomeController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public ActionResult Index()
        {
            var categories = _categoryRepository.GetAll().ToList();
            return View(categories);
        }
         
    }
}