using MovieStoreWebApp.Test.Definitions;
using MovieStoreWebApp.Test.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;

namespace MovieStoreWebApp.Test.Selenium
{
    [TestFixture]
    public class SeleniumTests
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            // Run MovieStoreWebApp manually, calling it automatically is going to be solved later...
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {

        }

        [Test]
        [TestCase(BrowserType.MicrosoftEdge)]
        [TestCase(BrowserType.Chrome)]
        [Parallelizable(ParallelScope.All)]
        [Description("The home page can be open")]
        public void TestThatMovieStoreCanBeOpen(BrowserType browserType)
        {
            string url = "https://localhost:5001";
            var browserApp = StartBrowser(browserType);
            browserApp.Navigate().GoToUrl(url);
            Assert.IsTrue(Retry.Until(() => browserApp.Title == "Home page - MovieStore"));
            browserApp.Quit();
        }

        public IWebDriver StartBrowser(BrowserType browserType)
        {
            if (browserType == BrowserType.Chrome)
            {
                var chromeOptions = new ChromeOptions();
                chromeOptions.AddArgument("--start-maximized");
                return new ChromeDriver(chromeOptions);
            }
            if (browserType == BrowserType.MicrosoftEdge)
            {
                var driver = new EdgeDriver(EdgeDriverService.CreateDefaultService(AppDomain.CurrentDomain.BaseDirectory, "msedgedriver.exe"));
                driver.Manage().Window.Maximize();
                return driver;
            }
            // Other browsers here...
            throw new NotSupportedException($"Browser type {browserType} not supported");
        }
    }
}
