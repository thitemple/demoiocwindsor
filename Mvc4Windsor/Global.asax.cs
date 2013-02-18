using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Mvc4Windsor.Infra;

namespace Mvc4Windsor
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        private static IWindsorContainer _container;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
            RegisterWindsor();
        }

        protected void Application_End()
        {
            _container.Dispose();
        }

        private static void RegisterWindsor()
        {
            _container = new WindsorContainer()
                .Install(FromAssembly.This());
            var windsorControllerFactory = new WindsorControllerFactory(_container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(windsorControllerFactory);
        }
    }
}