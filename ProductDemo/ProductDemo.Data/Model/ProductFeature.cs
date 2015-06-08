using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProductDemo.Data.Model
{
    public class ProductFeature
    {
        [Key]
        public int ProductFeatureId { get; set; }
        [Required]
        [DisplayName("Özellik")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Değer")]
        public string Value { get; set; }

        [Required]
        public virtual int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
