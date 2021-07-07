using MovieStoreWebApp.Test.Definitions;
using MovieStoreWebApp.Test.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System;

namespace MovieStoreWebApp.Test.Selenium
{
    [TestFixture(BrowserType.Chrome)]
    [TestFixture(BrowserType.MicrosoftEdge)]
    [Parallelizable(ParallelScope.All)]
    public class MovieStoreTests : MovieStoreTestBase
    {
        private readonly BrowserType _browserType;

        public MovieStoreTests(BrowserType browserType)
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
                var homePage = new HomePage();
                browser.Navigate().GoToUrl(homePage.Url);
                var wait = new WebDriverWait(browser, TimeSpan.FromSeconds(3));
                Assert.IsTrue(wait.Until((d) => homePage.Verify(browser)));
            }
        }

        [Test]
        [Description("The MovieStore Movies page can be open")]
        [Category(TestCategory.Smoke)]
        public void TestThatMoviesPageCanBeOpen()
        {
            using (var browser = StartBrowser(_browserType))
            {
                var moviesPage = new MoviesPage();
                browser.Navigate().GoToUrl(moviesPage.Url);
                var wait = new WebDriverWait(browser, TimeSpan.FromSeconds(3));
                Assert.IsTrue(wait.Until((d) => moviesPage.Verify(browser)));
            }
        }

        [Test]
        [Description("The MovieStore Privacy page can be open")]
        [Category(TestCategory.Smoke)]
        public void TestThatPrivacyPageCanBeOpen()
        {
            using (var browser = StartBrowser(_browserType))
            {
                var privacyPage = new PrivacyPage();
                browser.Navigate().GoToUrl(privacyPage.Url);
                var wait = new WebDriverWait(browser, TimeSpan.FromSeconds(3));
                Assert.IsTrue(wait.Until((d) => privacyPage.Verify(browser)));
            }
        }
    }
}
