using System.Linq;
using System.Web.Mvc;
using ProductDemo.Core.Infrastructure;
using ProductDemo.Web.ViewModel;

namespace ProductDemo.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var product = _productRepository.GetById(id.Value);

            if (product == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var allCategories = _categoryRepository.GetAll().ToList();

            var pageModel = new ProductPageModel
            {
                CurrentProduct = product,
                CategoryList = allCategories
            };

            return View(pageModel);
        }
    }
}
