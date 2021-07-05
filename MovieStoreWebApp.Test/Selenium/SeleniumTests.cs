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
    [TestFixture(BrowserType.Chrome)]
    [TestFixture(BrowserType.MicrosoftEdge)]
    [Parallelizable(ParallelScope.All)]
    public class SeleniumTests
    {
        private readonly BrowserType _browserType;

        public SeleniumTests(BrowserType browserType)
        {
            _browserType = browserType;
        }

        [Test]
        [Description("The MovieStore Home page can be open")]
        [Category(TestCategory.Smoke)]
        public void TestThatHomePageCanBeOpen()
        {
            using (var browser = StartBrowser(_browserType))
            {
                browser.Navigate().GoToUrl(HomePage.Url);
                Assert.IsTrue(Retry.Until(() => browser.Title == HomePage.Title));
            }
        }

        [Test]
        [Description("The MovieStore Movies page can be open")]
        [Category(TestCategory.Smoke)]
        public void TestThatMoviesPageCanBeOpen()
        {
            using (var browser = StartBrowser(_browserType))
            {
                browser.Navigate().GoToUrl(MoviesPage.Url);
                Assert.IsTrue(Retry.Until(() => browser.Title == MoviesPage.Title));
            }
        }

        [Test]
        [Description("The MovieStore Privacy page can be open")]
        [Category(TestCategory.Smoke)]
        public void TestThatPrivacyPageCanBeOpen()
        {
            using (var browser = StartBrowser(_browserType))
            {
                browser.Navigate().GoToUrl(PrivacyPage.Url);
                Assert.IsTrue(Retry.Until(() => browser.Title == PrivacyPage.Title));
            }
        }

        // TODO: move to test base class
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
