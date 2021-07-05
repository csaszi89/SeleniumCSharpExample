using MovieStoreWebApp.Test.Definitions;
using MovieStoreWebApp.Test.Pages;
using MovieStoreWebApp.Test.Utils;
using NUnit.Framework;

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
                Assert.IsTrue(Retry.Until(() => homePage.Verify(browser)));
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
                Assert.IsTrue(Retry.Until(() => moviesPage.Verify(browser)));
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
                Assert.IsTrue(Retry.Until(() => privacyPage.Verify(browser)));
            }
        }
    }
}
