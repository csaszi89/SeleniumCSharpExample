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
    public class HomePageTests : MovieStoreTestBase
    {
        private readonly BrowserType _browserType;

        public HomePageTests(BrowserType browserType)
        {
            _browserType = browserType;
        }

        [Test]
        [Category(TestCategory.Smoke)]
        public void Test_NavigateToHomePage()
        {
            using (var browser = StartBrowser(_browserType))
            {
                var homePage = browser.NavigateTo<HomePage>();
                Assert.IsTrue(homePage.Verify());
                Assert.AreEqual("This application was developed to demonstrate how to write tests by Selenium C#", homePage.P.Text);
            }
        }

        [Test]
        [Category(TestCategory.Smoke)]
        public void Test_RefreshHomePage()
        {
            using (var browser = StartBrowser(_browserType))
            {
                var homePage = browser.NavigateTo<HomePage>();
                browser.Navigate().Refresh();
                Assert.IsTrue(homePage.Verify());
            }
        }
    }
}
