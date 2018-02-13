using Microsoft.AspNet.SignalR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Owin;
using Owin;
using CorsOptions = Microsoft.Owin.Cors.CorsOptions;

[assembly: OwinStartup(typeof(MyUserStory.WEB.Startup))]

namespace MyUserStory.WEB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            app.Map("/signalr", map =>
            {

                var hubConfiguration = new HubConfiguration
                {

                    EnableJSONP = true
                };

                map.RunSignalR(hubConfiguration);
            });
            ConfigureAuth(app);          
        }

    }
}
    