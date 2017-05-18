using System.Web.Http;

namespace Apopad.WebServices
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            AutofacConfig.Initialize();
            AutoMapperConfig.Initialize();
        }
    }
}
