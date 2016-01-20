using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(USA_Music_Department.Startup))]
namespace USA_Music_Department
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
