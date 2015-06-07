using System.ComponentModel.DataAnnotations;

namespace ProductDemo.Data.Model
{
    public class ProductImage
    {
        [Key]
        public int Id { get; set; }
        public string ImageName { get; set; }
        public int Order { get; set; }

        [Required]
        public virtual Product Product { get; set; }
    }
}
