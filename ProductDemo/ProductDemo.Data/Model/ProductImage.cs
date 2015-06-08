using System.ComponentModel.DataAnnotations;

namespace ProductDemo.Data.Model
{
    public class ProductImage
    {
        [Key]
        public int ProductImageId { get; set; }
        [Required]
        public string ImageName { get; set; }
        [Required]
        public int Order { get; set; }

        [Required]
        public virtual int ProductId { get; set; }
        [Required]
        public virtual Product Product { get; set; }
    }
}
