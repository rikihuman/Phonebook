using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Phonebook.Web.Startup))]
namespace Phonebook.Web
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
