using MovieStoreWebApp.Test.Definitions;
using MovieStoreWebApp.Test.Pages;
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
            using (var browser = StartBrowser(browserType))
            {
                browser.Navigate().GoToUrl(HomePage.Url);
                Assert.IsTrue(Retry.Until(() => browser.Title == HomePage.Title));
            }
        }

        public IWebDriver StartBrowser(BrowserType browserType)
        {
            if (browserType == BrowserType.Chrome)
            {
                var chromeOptions = new ChromeOptions();
                chromeOptions.AddArgument("--start-maximized");
                return new ChromeDriver(ChromeDriverService.CreateDefaultService(AppDomain.CurrentDomain.BaseDirectory, FileNames.ChromeDriverExecutable), chromeOptions);
            }
            if (browserType == BrowserType.MicrosoftEdge)
            {
                var driver = new EdgeDriver(EdgeDriverService.CreateDefaultService(AppDomain.CurrentDomain.BaseDirectory, FileNames.EdgeDriverExecutable));
                driver.Manage().Window.Maximize();
                return driver;
            }
            // Other browsers here...
            throw new NotSupportedException($"Browser type {browserType} not supported");
        }
    }
}
