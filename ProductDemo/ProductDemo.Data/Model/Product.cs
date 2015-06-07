using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductDemo.Data.Model
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string ProductName { get; set; }

        public virtual ICollection<ProductFeature> ProductFeatures { get; set; }
        [Required]
        public virtual Category Category { get; set; }
    }
}
