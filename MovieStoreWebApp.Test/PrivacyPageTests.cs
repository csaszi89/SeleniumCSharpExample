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
    public class PrivacyPageTests : MovieStoreTestBase
    {
        private readonly BrowserType _browserType;

        public PrivacyPageTests(BrowserType browserType)
        {
            _browserType = browserType;
        }

        [Test]
        [Category(TestCategory.Smoke)]
        public void Test_NavigateToPrivacyPage()
        {
            using (var browser = StartBrowser(_browserType))
            {
                var privacyPage = browser.NavigateTo<PrivacyPage>();
                Assert.IsTrue(privacyPage.Verify());
                Assert.AreEqual("Use this page to detail your site's privacy policy.", privacyPage.P.Text);
            }
        }

        [Test]
        [Category(TestCategory.Smoke)]
        public void Test_RefreshPrivacyPage()
        {
            using (var browser = StartBrowser(_browserType))
            {
                var privacyPage = browser.NavigateTo<PrivacyPage>();
                browser.Navigate().Refresh();
                Assert.IsTrue(privacyPage.Verify());
            }
        }
    }
}
