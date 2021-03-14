﻿using Interop.UIAutomationClient;
using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Threading;

namespace MovieStoreWebApp.Test.UIAutomation
{
    public enum BrowserType
    {
        Chrome,
        MicrosoftEdge
    }

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

            while (browserApp.MainWindowHandle == IntPtr.Zero)
            {
                Thread.Sleep(100);
            }

            var aut = new CUIAutomation8();
            var browserWindow = aut.ElementFromHandle(browserApp.MainWindowHandle);
            Assert.IsNotNull(browserWindow);

            var tabItem = browserWindow.FindFirst(TreeScope.TreeScope_Descendants, aut.CreatePropertyCondition(UIA_PropertyIds.UIA_ControlTypePropertyId, UIA_ControlTypeIds.UIA_TabItemControlTypeId));

            while (tabItem.CurrentName != "Home page - MovieStore")
            {
                Thread.Sleep(100);
            }
        }

        private Process StartBrowser(BrowserType browserType, string url)
        {
            return browserType == BrowserType.MicrosoftEdge ? Process.Start($"microsoft-edge:{url}") : Process.Start($"chrome.exe", url);
        }
    }
}
