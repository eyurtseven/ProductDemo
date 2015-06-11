using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProductDemo.Data.Model;

namespace ProductDemo.Web.ViewModel
{
    public class ProductPageModel
    {
        public Product CurrentProduct { get; set; }
        public List<Category> CategoryList { get; set; }
    }
}