using Interop.UIAutomationClient;
using MovieStoreWebApp.Test.Definitions;
using MovieStoreWebApp.Test.Utils;
using NUnit.Framework;
using System;
using System.Diagnostics;

namespace MovieStoreWebApp.Test.UIAutomation
{
    [TestFixture]
    public class UIAutomationTests
    {
        //Process _webApp;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            //var psi = new ProcessStartInfo(@".\..\..\..\..\MovieStoreWebApp\bin\Debug\netcoreapp3.1\MovieStoreWebApp.exe")
            //{
            //    WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory
            //};

            //_webApp = Process.Start(psi);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            //_webApp.Kill();
        }

        [Test]
        [TestCase(BrowserType.MicrosoftEdge)]
        [TestCase(BrowserType.Chrome)]
        [Parallelizable(ParallelScope.All)]
        [Description("The home page can be open")]
        public void TestThatMovieStoreCanBeOpen(BrowserType browserType)
        {
            string url = "https://localhost:5001";
            var browserApp = StartBrowser(browserType, url);

            _ = Retry.Until(() => browserApp.MainWindowHandle != IntPtr.Zero);

            var aut = new CUIAutomation8();
            var browserWindow = aut.ElementFromHandle(browserApp.MainWindowHandle);
            Assert.IsNotNull(browserWindow);

            var tabItem = browserWindow.FindFirst(TreeScope.TreeScope_Descendants, aut.CreatePropertyCondition(UIA_PropertyIds.UIA_ControlTypePropertyId, UIA_ControlTypeIds.UIA_TabItemControlTypeId));

            Assert.IsTrue(Retry.Until(() => tabItem.CurrentName == "Home page - MovieStore"));

            browserApp.CloseMainWindow();
            browserApp.WaitForExit();
        }

        private Process StartBrowser(BrowserType browserType, string url)
        {
            var psi = new ProcessStartInfo
            {
                WindowStyle = ProcessWindowStyle.Maximized
            };
            if (browserType == BrowserType.MicrosoftEdge)
            {
                psi.FileName = $"microsoft-edge:{url}";
            }
            else
            {
                psi.FileName = "chrome.exe";
                psi.Arguments = url;
            }
            return Process.Start(psi);
        }
    }
}
