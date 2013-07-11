using System.Web.Mvc;
using NUnit.Framework;
using PrivateZone.Web.Controllers;
using SharpTestsEx;

namespace PrivateZone.Tests.Web.Controllers
{
    [TestFixture]
    public class HomeControllerTests
    {
        private void AssertDefaultView(ViewResult viewResult)
        {
            viewResult.Should().Not.Be.Null();
            viewResult.ViewName.Should().Be.Empty();
        }

        private HomeController CreateCommonController()
        {
            return new HomeController();
        }

        [Test]
        public void Index_DefaultAction_ReturnsIndexView()
        {
            // Arrange
            var homeController = CreateCommonController();
            // Act
            var result = homeController.Index() as ViewResult;

            // Assert
            AssertDefaultView(result);
        }
    }
}