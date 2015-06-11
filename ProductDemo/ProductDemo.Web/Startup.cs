using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProductDemo.Web.Startup))]
namespace ProductDemo.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
        }
    }
}
