using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProductDemo.Data.Model
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        [DisplayName("Ürün Adı")]
        public string ProductName { get; set; }

        public virtual ICollection<ProductFeature> ProductFeatures { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }
        [Required]
        public virtual int CategoryId { get; set; }
        [DisplayName("Kategori")]
        public virtual Category Category { get; set; }
    }
}
