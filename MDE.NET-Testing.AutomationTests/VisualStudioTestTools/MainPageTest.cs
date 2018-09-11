
using MDE.NET_Testing.AutomationTests.VisualStudioTestTools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace MDE.NET_Testing.AutomationTests
{
    [TestClass]
    public class MainPageTest : TestBaseVSTT
    {

        [TestMethod]
        public void TestMethod1()
        {
            driver.Navigate().GoToUrl(appURL + "/");
            driver.FindElement(By.Id("sb_form_q")).SendKeys("Azure Pipelines");
            driver.FindElement(By.Id("sb_form_go")).Click();
            driver.FindElement(By.XPath("//ol[@id='b_results']/li/h2/a/strong[3]")).Click();
            Assert.IsTrue(driver.Title.Contains("Azure Pipelines"), "Verified title of the page");
        }





    }
}
