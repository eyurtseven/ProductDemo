namespace ProductDemo.Data.Model
{
    public class ProductFeature
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

        public virtual Product Product { get; set; }
    }
}
