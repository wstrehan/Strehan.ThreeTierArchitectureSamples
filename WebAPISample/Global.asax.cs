using System.Web.Http;
using System.Web.Http.Dispatcher;

namespace WebAPISample
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //Setup the web service
            GlobalConfiguration.Configure(WebApiConfig.Register);

            //Custom HttpControllerActivator needed for dependency injection into StockController
            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator), new WebAPISample.Controllers.HttpControllerActivator());
        }
    }
}
