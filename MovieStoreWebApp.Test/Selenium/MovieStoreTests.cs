using MovieStoreWebApp.Test.Definitions;
using MovieStoreWebApp.Test.Extensions;
using MovieStoreWebApp.Test.Pages;
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
                Assert.IsTrue(browser.NavigateTo<HomePage>().Verify());
            }
        }

        [Test]
        [Description("The MovieStore Movies page can be open")]
        [Category(TestCategory.Smoke)]
        public void TestThatMoviesPageCanBeOpen()
        {
            using (var browser = StartBrowser(_browserType))
            {
                Assert.IsTrue(browser.NavigateTo<MoviesPage>().Verify());
            }
        }

        [Test]
        [Description("The MovieStore Privacy page can be open")]
        [Category(TestCategory.Smoke)]
        public void TestThatPrivacyPageCanBeOpen()
        {
            using (var browser = StartBrowser(_browserType))
            {
                Assert.IsTrue(browser.NavigateTo<PrivacyPage>().Verify());
            }
        }

        [Test]
        [Description("The Movies button navigates to the Movies page")]
        [Category(TestCategory.Smoke)]
        public void TestThatUserCanNavigateToMoviesPage()
        {
            using (var browser = StartBrowser(_browserType))
            {
                var homePage = browser.NavigateTo<HomePage>();
                var moviesPage = homePage.ClickMoviesLink();
                Assert.IsTrue(moviesPage.Verify());
            }
        }

        [Test]
        [Description("The Privacy button navigates to the Privacy page")]
        [Category(TestCategory.Smoke)]
        public void TestThatUserCanNavigateToPrivacyPage()
        {
            using (var browser = StartBrowser(_browserType))
            {
                var homePage = browser.NavigateTo<HomePage>();
                var privacyPage = homePage.ClickPrivacyLink();
                Assert.IsTrue(privacyPage.Verify());
            }
        }
    }
}
