using System;
using System.ServiceModel.Activation;
using System.Web;
using System.Web.Routing;

namespace RestService
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes();
        }

        private void RegisterRoutes()
        {
            // Edit the base address of Service by replacing the "Service" string below
            RouteTable.Routes.Add(new ServiceRoute("Service", new WebServiceHostFactory(), typeof(Service)));
        }
    }
}
