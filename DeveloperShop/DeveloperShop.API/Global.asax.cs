using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace DeveloperShop.API
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            DependencyInjectionConfig.Register();
        }
    }
}