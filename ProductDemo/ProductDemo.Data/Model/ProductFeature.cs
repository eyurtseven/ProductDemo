using System.ComponentModel.DataAnnotations;

namespace ProductDemo.Data.Model
{
    public class ProductFeature
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

        [Required]
        public virtual Product Product { get; set; }
    }
}
