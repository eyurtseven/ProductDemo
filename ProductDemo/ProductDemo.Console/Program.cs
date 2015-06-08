using System.Linq;
using ProductDemo.Data.DataContext;

namespace ProductDemo.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new ProductDemoContext();
            var c = context.Category.ToList();
        }
    }
}
