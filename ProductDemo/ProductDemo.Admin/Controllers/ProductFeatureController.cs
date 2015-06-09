using System.Net;
using System.Web.Mvc;
using ProductDemo.Core.Infrastructure;
using ProductDemo.Data.Model;

namespace ProductDemo.Admin.Controllers
{
    public class ProductFeatureController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductFeatureRepository _productFeatureRepository;

        public ProductFeatureController(IProductRepository productRepository, IProductFeatureRepository productFeatureRepository)
        {
            _productRepository = productRepository;
            _productFeatureRepository = productFeatureRepository;
        }

        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = GetCurrentProduct(id.Value);
            var productFeatures = product.ProductFeatures;

            ViewBag.SelectedProduct = product;
            return View(productFeatures);
        }

        public ActionResult Details(int? id, int? productId)
        {
            if (id == null || productId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var product = GetCurrentProduct(productId.Value);
            ViewBag.SelectedProduct = product;

            var productFeature = _productFeatureRepository.GetById(id.Value);
            if (productFeature == null)
            {
                return HttpNotFound();
            }
            return View(productFeature);
        }

        public ActionResult Create(int? id)
        {
            var product = _productRepository.GetById(id.Value);

            ViewBag.SelectedProduct = product;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int? id, ProductFeature productFeature)
        {
            productFeature.ProductId = id.Value;
            _productFeatureRepository.Insert(productFeature);
            _productFeatureRepository.Save();
            return RedirectToAction("Index", new { id = id.Value });
        }

        public ActionResult Edit(int? id, int? productId)
        {
            if (id == null || productId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var product = GetCurrentProduct(productId.Value);
            ViewBag.SelectedProduct = product;

            var productFeature = _productFeatureRepository.GetById(id.Value);
            if (productFeature == null)
            {
                return HttpNotFound();
            }

            return View(productFeature);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductFeature productFeature)
        {
            if (!ModelState.IsValid) return View(productFeature);

            _productFeatureRepository.Update(productFeature);
            _productFeatureRepository.Save();
            return RedirectToAction("Index", new { id = productFeature.ProductId });
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var productFeature = _productFeatureRepository.GetById(id.Value);
            if (productFeature == null)
            {
                return HttpNotFound();
            }
            return View(productFeature);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, FormCollection col)
        {
            _productFeatureRepository.Delete(id);
            _productFeatureRepository.Save();
            return RedirectToAction("Index", new { id = col["productId"] });
        }

        private Product GetCurrentProduct(int id)
        {
            var product = _productRepository.GetById(id);
            return product;
        }

    }
}
