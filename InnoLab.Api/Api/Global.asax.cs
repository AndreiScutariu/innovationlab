using System.Web.Http;

namespace Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            Bus.MassTransitBus.Start();
        }

        protected void Application_Stop()
        {
            Bus.MassTransitBus.Stop();
        }
    }
}
