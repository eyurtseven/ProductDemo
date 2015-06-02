using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
