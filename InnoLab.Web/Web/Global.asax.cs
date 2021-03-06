﻿using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Web.Bus;

namespace Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            MassTransitBus.Start();
        }

        protected void Application_Stop()
        {
            MassTransitBus.Stop();
        }
    }
}
