using System.ComponentModel.DataAnnotations;

namespace ProductDemo.Data.Model
{
    public class ProductFeature
    {
        [Key]
        public int ProductFeatureId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Value { get; set; }

        [Required]
        public virtual int ProductId { get; set; }
        [Required]
        public virtual Product Product { get; set; }
    }
}
