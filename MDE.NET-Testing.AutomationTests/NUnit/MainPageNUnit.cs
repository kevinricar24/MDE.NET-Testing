

using NUnit.Framework;
using OpenQA.Selenium;

namespace MDE.NET_Testing.AutomationTests.NUnit
{

    [TestFixture]
    class MainPageNUnit : TestBaseNUnit
    {

        protected override void OnSetUp()
        {
            driver.Navigate().GoToUrl(GlobalsWords.URLPage);
            Assert.AreEqual(GlobalsWords.TitlePageHome, driver.Title, msgerror(GlobalsWords.TitlePageHome, driver.Title));
        }


        [Test]
        public void TestCase001_ValidateSectionUpHome()
        {
            var Title = driver.FindElement(By.ClassName("jumbotron")).FindElement(By.TagName("h1"));
            Assert.AreEqual(GlobalsWords.HomeTitle, Title.Text, msgerror(GlobalsWords.HomeTitle, Title.Text));

            var paragraph = driver.FindElement(By.ClassName("lead"));
            Assert.AreEqual(GlobalsWords.HomeParagraph, paragraph.Text, msgerror(GlobalsWords.HomeParagraph, paragraph.Text));

            var link = driver.FindElement(By.CssSelector(".btn.btn-primary.btn-lg"));
            Assert.AreEqual(GlobalsWords.HomelinkText, link.Text, msgerror(GlobalsWords.HomelinkText, link.Text));

            link.Click();
            Assert.AreEqual(GlobalsWords.Homelink, driver.Url, msgerror(GlobalsWords.Homelink, driver.Url));
        }


    }
}
