using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ProductDemo.Data.Model;

namespace ProductDemo.Data.DataContext
{
    public class ProductDemoContext : DbContext
    {
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}
