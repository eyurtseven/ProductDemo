namespace ProductDemo.Data.Model
{
    public class ProductImage
    {
        public int Id { get; set; }
        public string ImageName { get; set; }
        public int Order { get; set; }

        public virtual Product Product { get; set; }
    }
}
