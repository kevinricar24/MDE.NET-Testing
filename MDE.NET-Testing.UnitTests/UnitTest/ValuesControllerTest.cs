using MDE.NET_Testing.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace MDE.NET_Testing.UnitTests.UnitTest
{
    [TestClass]
    public class ValuesControllerTest
    {
        [TestMethod]
        public void Get()
        {
            // Arrange
            ValuesController controller = new ValuesController();

            // Act
            Dictionary<int, string> result = controller.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count());
            Assert.AreEqual("value0", result.ElementAt(0).Value);
            Assert.AreEqual("value1", result.ElementAt(1).Value);
        }

        [TestMethod]
        public void GetById()
        {
            // Arrange
            ValuesController controller = new ValuesController();
            int Id = 2;

            // Act
            string result = controller.Get(Id);

            // Assert
            Assert.AreEqual("value2", result);
        }

        [TestMethod]
        public void Post()
        {
            // Arrange
            ValuesController controller = new ValuesController();
            string value = "value3";

            // Act
            string result = controller.Post(value);

            // Assert
            Assert.AreEqual(value + " added!", result);
        }

        [TestMethod]
        public void Put()
        {
            // Arrange
            ValuesController controller = new ValuesController();
            int Id = 3;
            string value = "new value3";

            // Act
            string result = controller.Put(Id, value);

            // Assert
            Assert.AreEqual(value + " updated!", result);
        }

        [TestMethod]
        public void Delete()
        {
            // Arrange
            ValuesController controller = new ValuesController();
            int Id = 2;

            // Act
            string result = controller.Delete(Id);

            // Assert
            Assert.AreEqual(Id + " removed!", result);
        }
    }
}
