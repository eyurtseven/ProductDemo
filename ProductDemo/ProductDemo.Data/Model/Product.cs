using System.Collections.Generic;

namespace ProductDemo.Data.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }

        public virtual ICollection<ProductFeature> ProductFeatures { get; set; }
        public virtual Category Category { get; set; }
    }
}
