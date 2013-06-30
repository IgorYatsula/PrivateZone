using System.Web.Routing;
using NUnit.Framework;
using PrivateZone.Web;
using MvcRouteTester;
using PrivateZone.Web.Controllers;

namespace PrivateZone.Tests.Web.Configs
{
    [TestFixture]
    public class RouteConfigTests
    {
        [Test]
        public void TestIncomingRoutes()
        {
            // Arrange
            var routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            // Assert
            routes.ShouldMap("/handler.axd/pathInfo").ToIgnoredRoute();
            routes.ShouldMap("/").To<HomeController>(x => x.Index());
            routes.ShouldMap("/home").To<HomeController>(x => x.Index());
            routes.ShouldMap("/home/index").To<HomeController>(x => x.Index());
            routes.ShouldMap("/home/index/32").To<HomeController>(x => x.Index());
            routes.ShouldMap("/foo/bar/fish/spon").ToNoRoute();
        }
    }
}