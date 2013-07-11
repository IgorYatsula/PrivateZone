using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.MicroKernel.Registration;
using Castle.Windsor.Mvc;
using PrivateZone.Locator;

namespace PrivateZone.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            InitIoC();
        }

        private void InitIoC()
        {
            IoC.Current.Init();
            IoC.Current.Container.Register(Classes.FromThisAssembly().BasedOn<IController>().LifestyleTransient());
            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(IoC.Current.Container.Kernel));
        }
    }
}