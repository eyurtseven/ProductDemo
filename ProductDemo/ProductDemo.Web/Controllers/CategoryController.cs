using System.Linq;
using System.Web.Mvc;
using ProductDemo.Core.Infrastructure;
using ProductDemo.Web.ViewModel;

namespace ProductDemo.Web.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var allCategories = _categoryRepository.GetAll().ToList();

            var category = allCategories.FirstOrDefault(x => x.CategoryId == id);

            if (category == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var products = category.Products.ToList();

            var pageModel = new CategoryPageModel()
            {
                CurrentCategory = category,
                CategoryList = allCategories,
                ProductList = products
            };

            return View(pageModel);
        }
    }
}
