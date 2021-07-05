using Interop.UIAutomationClient;
using MovieStoreWebApp.Test.Definitions;
using MovieStoreWebApp.Test.Pages;
using MovieStoreWebApp.Test.Utils;
using NUnit.Framework;
using System;
using System.Diagnostics;

namespace MovieStoreWebApp.Test.UIAutomation
{
    [TestFixture]
    public class UIAutomationTests
    {
        [Test]
        [TestCase(BrowserType.MicrosoftEdge)]
        [TestCase(BrowserType.Chrome)]
        [Parallelizable(ParallelScope.All)]
        [Description("The home page can be open")]
        public void TestThatMovieStoreCanBeOpen(BrowserType browserType)
        {
            var homePage = new HomePage();
            var browserApp = StartBrowser(browserType, homePage.Url);

            _ = Retry.Until(() => browserApp.MainWindowHandle != IntPtr.Zero);

            var aut = new CUIAutomation8();
            var browserWindow = aut.ElementFromHandle(browserApp.MainWindowHandle);
            Assert.IsNotNull(browserWindow);

            var tabItem = browserWindow.FindFirst(TreeScope.TreeScope_Descendants, aut.CreatePropertyCondition(UIA_PropertyIds.UIA_ControlTypePropertyId, UIA_ControlTypeIds.UIA_TabItemControlTypeId));

            Assert.IsTrue(Retry.Until(() => tabItem.CurrentName == homePage.Title));

            browserApp.CloseMainWindow();
            browserApp.WaitForExit();
            browserApp.Dispose();
        }

        private Process StartBrowser(BrowserType browserType, string url)
        {
            var psi = new ProcessStartInfo
            {
                WindowStyle = ProcessWindowStyle.Maximized
            };

            if (browserType == BrowserType.Chrome)
            {
                psi.FileName = "chrome.exe";
                psi.Arguments = url;
            }
            else if (browserType == BrowserType.MicrosoftEdge)
            {
                psi.FileName = $"microsoft-edge:{url}";
            }
            else
            {
                throw new NotSupportedException($"Browser type {browserType} not supported");
            }
            return Process.Start(psi);
        }
    }
}
