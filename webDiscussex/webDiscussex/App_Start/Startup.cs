using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Owin.Security.Google;
using Owin;

[assembly: OwinStartup(typeof(webDiscussex.App_Start.Startup))]

namespace webDiscussex.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Para obter mais informações sobre como configurar seu aplicativo, visite https://go.microsoft.com/fwlink/?LinkID=316888

            app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            {
                ClientId = "781467258809-pqp31ot7hutff31m4p3a5nceld3illf3.apps.googleusercontent.com",
                ClientSecret = "G5Osq0DeQSd2yJNxQx8IRiWK"

            });
        }
    }
}
