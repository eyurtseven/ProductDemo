using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProductDemo.Core.Infrastructure;
using ProductDemo.Data.Model;
using WebGrease.Css.Extensions;

namespace ProductDemo.Admin.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductImageRepository _productImageRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository, IProductImageRepository productImageRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _productImageRepository = productImageRepository;
        }

        public ActionResult Index()
        {
            var productList = _productRepository.GetAll().ToList();
            return View(productList);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SetCategoryList();
            var product = _productRepository.GetById(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        public ActionResult Create()
        {
            SetCategoryList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product, HttpPostedFileBase productImage)
        {
            if (productImage != null && productImage.ContentLength > 0)
            {
                var img = new ProductImage();
                img.ImageName = Path.GetFileName(productImage.FileName);
                img.ContentType = productImage.ContentType;
                using (var reader = new BinaryReader(productImage.InputStream))
                {
                    img.Content = reader.ReadBytes(productImage.ContentLength);
                }
                product.ProductImages = new List<ProductImage> { img };
            }
            _productRepository.Insert(product);
            _productRepository.Save();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = _productRepository.GetById(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            SetCategoryList(product.CategoryId);

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product, HttpPostedFileBase productImage)
        {
            if (!ModelState.IsValid) return View(product);
            _productRepository.Update(product);
            _productRepository.Save();

            if (productImage == null || productImage.ContentLength <= 0) return RedirectToAction("Index");

            var img = new ProductImage
            {
                ImageName = Path.GetFileName(productImage.FileName),
                ContentType = productImage.ContentType
            };
            using (var reader = new BinaryReader(productImage.InputStream))
            {
                img.Content = reader.ReadBytes(productImage.ContentLength);
                img.ProductId = product.ProductId;
            }
            var existingImage = _productRepository.GetById(product.ProductId).ProductImages;
            if (existingImage != null && existingImage.Count > 0)
            {
                existingImage.ForEach(x => _productImageRepository.Delete(x.ProductImageId));
            }

            _productImageRepository.Insert(img);
            _productImageRepository.Save();
            
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = _productRepository.GetById(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _productRepository.Delete(id);
            _productRepository.Save();
            return RedirectToAction("Index");
        }

        private void SetCategoryList(object selectedCategory = null)
        {
            var categoryList = _categoryRepository.GetAll();
            var selectList = new SelectList(categoryList, "CategoryId", "CategoryName", selectedCategory);
            ViewData.Add("CategoryId", selectList);
        }
    }
}
