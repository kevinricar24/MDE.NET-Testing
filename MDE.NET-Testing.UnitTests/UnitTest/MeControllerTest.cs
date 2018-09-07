using MDE.NET_Testing.Controllers;
using MDE.NET_Testing.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MDE.NET_Testing.UnitTests.UnitTest
{
    [TestClass]
    public class MeControllerTest
    {
        [TestMethod]
        public void GetHomeTownWhenUserNotIsAuthenticated()
        {
            // Arrange
            MeController controller = new MeController();
            ApplicationUser appuser = new ApplicationUser();
            appuser.Hometown = null;

            // Act
            GetViewModel result = controller.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(appuser.Hometown, result.Hometown);
        }

    }
}
