using MovieStoreWebApp.Test.Definitions;
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
                Assert.IsTrue(new HomePage(browser).NavigateTo());
            }
        }

        [Test]
        [Description("The MovieStore Movies page can be open")]
        [Category(TestCategory.Smoke)]
        public void TestThatMoviesPageCanBeOpen()
        {
            using (var browser = StartBrowser(_browserType))
            {
                Assert.IsTrue(new MoviesPage(browser).NavigateTo());
            }
        }

        [Test]
        [Description("The MovieStore Privacy page can be open")]
        [Category(TestCategory.Smoke)]
        public void TestThatPrivacyPageCanBeOpen()
        {
            using (var browser = StartBrowser(_browserType))
            {
                Assert.IsTrue(new PrivacyPage(browser).NavigateTo());
            }
        }

        [Test]
        [Description("The Movies button navigates to the Movies page")]
        [Category(TestCategory.Smoke)]
        public void TestThatUserCanNavigateToMoviesPage()
        {
            using (var browser = StartBrowser(_browserType))
            {
                var homePage = new HomePage(browser);
                _ = homePage.NavigateTo();
                Assert.IsTrue(homePage.NavigateTo<MoviesPage>(homePage.MoviesLink, out _));
            }
        }

        [Test]
        [Description("The Privacy button navigates to the Privacy page")]
        [Category(TestCategory.Smoke)]
        public void TestThatUserCanNavigateToPrivacyPage()
        {
            using (var browser = StartBrowser(_browserType))
            {
                var homePage = new HomePage(browser);
                _ = homePage.NavigateTo();
                Assert.IsTrue(homePage.NavigateTo<PrivacyPage>(homePage.PrivacyLink, out _));
            }
        }
    }
}
