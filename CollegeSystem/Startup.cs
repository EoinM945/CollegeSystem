using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CollegeSystem.Startup))]
namespace CollegeSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
