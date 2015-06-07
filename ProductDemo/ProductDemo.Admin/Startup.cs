using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProductDemo.Admin.Startup))]
namespace ProductDemo.Admin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
        }
    }
}
