using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using LearnWords.App_Start;
using Microsoft.Practices.Unity;

namespace LearnWords
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static IUnityContainer Unity;

        protected void Application_Start()
        {
            Unity = new UnityContainer();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            GlobalConfiguration.Configure(WebApiConfig.Register);

            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            UnityConfig.RegisterTypes(Unity);
            
            //WebApiConfig.Register(GlobalConfiguration.Configuration);
        }
    }
}
