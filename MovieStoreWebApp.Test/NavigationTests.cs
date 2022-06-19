using MovieStoryWebApp.Test.Utils;
using MovieStoryWebApp.Test.Utils.Definitions;
using MovieStoryWebApp.Test.Utils.Extensions;
using MovieStoryWebApp.Test.Utils.Pages;
using NUnit.Framework;

namespace MovieStoreWebApp.Test
{
    [TestFixture(BrowserType.Chrome)]
    [TestFixture(BrowserType.MicrosoftEdge)]
    [Parallelizable(ParallelScope.All)]
    public class NavigationTests : MovieStoreTestBase
    {
        private readonly BrowserType _browserType;

        public NavigationTests(BrowserType browserType)
        {
            _browserType = browserType;
        }

        [Test]
        [Category(TestCategory.Smoke)]
        public void Test_NavigateToMovies()
        {
            using (var browser = StartBrowser(_browserType))
            {
                var homePage = browser.NavigateTo<HomePage>();
                var moviesPage = homePage.NavigationBar.ClickMoviesLink();
                Assert.IsTrue(moviesPage.Verify());
            }
        }

        [Test]
        [Category(TestCategory.Smoke)]
        public void Test_NavigateToPrivacy()
        {
            using (var browser = StartBrowser(_browserType))
            {
                var homePage = browser.NavigateTo<HomePage>();
                var privacyPage = homePage.NavigationBar.ClickPrivacyLink();
                Assert.IsTrue(privacyPage.Verify());
            }
        }

        [Test]
        [Category(TestCategory.Smoke)]
        public void Test_NavigateToHome()
        {
            using (var browser = StartBrowser(_browserType))
            {
                var homePage = browser.NavigateTo<HomePage>();
                var privacyPage = homePage.NavigationBar.ClickPrivacyLink();
                homePage = privacyPage.NavigationBar.ClickHomeLink();
                Assert.IsTrue(homePage.Verify());
            }
        }
    }
}
