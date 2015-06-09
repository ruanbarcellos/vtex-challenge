using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace DeveloperShop.API
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            DependencyInjectionConfig.Register();
        }
    }
}