using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.IO;

namespace MDE.NET_Testing.AutomationTests.NUnit
{
    public abstract class TestBaseNUnit
    {

        protected IWebDriver driver;
        protected string appURL;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Console.WriteLine("OneTimeSetUp");
            driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
            OnOneTimeSetUp();
        }

        [SetUp]
        public void SetUp()
        {
            Console.WriteLine("SetUp");
            Console.WriteLine(@"Running {0}", GetTestName());
            OnSetUp();
        }

        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("TearDown");
            OnTearDown();
            string ResultTest = string.Empty;
            ResultTest = TestContext.CurrentContext.Result.Outcome.Status.ToString();
            if (driver == null) return;

            try
            {
                //Here the code to capture javascipt errors
            }
            finally
            {
                if (ResultTest.Equals("Failed"))
                {
                    CaptureImage(ResultTest, string.Empty);
                }
            }
            Console.WriteLine(@"" + ResultTest + " {0}", GetTestName());
        }


        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Console.WriteLine("OneTimeTearDown");
            OnOneTimeTearDown();
            if (driver != null)
            {
                driver.Manage().Cookies.DeleteAllCookies();
                driver.Quit();
            }
        }

        protected virtual void OnOneTimeSetUp()
        {
            Console.WriteLine("OnOneTimeSetUp");
        }

        protected virtual void OnSetUp()
        {
            Console.WriteLine("OnSetUp");
        }

        protected virtual void OnTearDown()
        {
            Console.WriteLine("OnTearDown");
        }

        protected virtual void OnOneTimeTearDown()
        {
            Console.WriteLine("OnOneTimeTearDown");
        }

        private static string GetTestName()
        {
            return TestContext.CurrentContext.Test.FullName;
        }

        public string msgerror(string var1, string var2)
        {
            return "Error: the values " + var1 + " = " + var2 + " Should be equals";
        }

        private void CaptureImage(string folder, string captureName)
        {
            try
            {
                var captureDriver = driver as ITakesScreenshot;
                if (captureDriver != null)
                {
                    var screenshot = captureDriver.GetScreenshot();
                    var path = Path.Combine(TestContext.CurrentContext.WorkDirectory, folder);
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    string captureSuffix = string.Empty;
                    if (!string.IsNullOrEmpty(captureName))
                    {
                        captureSuffix = "_" + captureName;
                    }

                    var filename = string.Format("{0}{1}.png", TestContext.CurrentContext.Test.FullName, captureSuffix);
                    screenshot.SaveAsFile(Path.Combine(path, filename), ScreenshotImageFormat.Png);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
