using MovieStoreWebApp.Test.Definitions;
using MovieStoreWebApp.Test.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

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

        [Test]
        [Description("The Movies button navigates to the Movies page")]
        [Category(TestCategory.Smoke)]
        public void TestThatUserCanNavigateToMoviesPage()
        {
            using (var browser = StartBrowser(_browserType))
            {
                var homePage = new HomePage();
                browser.Navigate().GoToUrl(homePage.Url);
                var wait = new WebDriverWait(browser, TimeSpan.FromSeconds(3));
                var moviesButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText("Movies")));
                moviesButton.Click();
                var moviesPage = new MoviesPage();
                Assert.IsTrue(wait.Until((d) => moviesPage.Verify(browser)));
            }
        }

        [Test]
        [Description("The Privacy button navigates to the Privacy page")]
        [Category(TestCategory.Smoke)]
        public void TestThatUserCanNavigateToPrivacyPage()
        {
            using (var browser = StartBrowser(_browserType))
            {
                var homePage = new HomePage();
                browser.Navigate().GoToUrl(homePage.Url);
                var wait = new WebDriverWait(browser, TimeSpan.FromSeconds(3));
                var privacyButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText("Privacy")));
                privacyButton.Click();
                var privacyPage = new PrivacyPage();
                Assert.IsTrue(wait.Until((d) => privacyPage.Verify(browser)));
            }
        }
    }
}
