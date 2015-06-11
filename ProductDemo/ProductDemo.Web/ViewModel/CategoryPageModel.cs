using System.Collections.Generic;
using ProductDemo.Data.Model;

namespace ProductDemo.Web.ViewModel
{
    public class CategoryPageModel
    {
        public Category CurrentCategory { get; set; }
        public List<Category> CategoryList { get; set; }
        public List<Product> ProductList { get; set; }
    }
}