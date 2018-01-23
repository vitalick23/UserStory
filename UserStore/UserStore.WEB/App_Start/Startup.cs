using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using UserStore.BLL.Services;
using Microsoft.AspNet.Identity;
using UserStore.BLL.Interfaces;

[assembly: OwinStartup(typeof(UserStore.App_Start.Startup))]

namespace UserStore.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });
        }
        
    }
}
