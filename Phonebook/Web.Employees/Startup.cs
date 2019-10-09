using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Web.Employees.Startup))]
namespace Web.Employees
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
