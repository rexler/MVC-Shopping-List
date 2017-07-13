using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SimpleShoppingList.Startup))]
namespace SimpleShoppingList
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
