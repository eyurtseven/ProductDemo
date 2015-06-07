using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductDemo.Data.Model
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
