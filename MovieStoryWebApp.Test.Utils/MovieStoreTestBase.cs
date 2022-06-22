using MovieStoreWebApp.Test.Utils.Definitions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Remote;
using System;

namespace MovieStoreWebApp.Test.Utils
{
    public class MovieStoreTestBase
    {
        public IWebDriver StartBrowser(BrowserType browser)
        {
            DriverOptions options;
            switch (browser)
            {
                case BrowserType.Chrome:
                    options = new ChromeOptions();
                    break;
                case BrowserType.MicrosoftEdge:
                    options = new EdgeOptions();
                    break;
                default:
                    throw new NotSupportedException($"Browser type {browser} not supported");
            }

            options.UnhandledPromptBehavior = UnhandledPromptBehavior.Ignore;
            options.AcceptInsecureCertificates = true;
            var driver = new RemoteWebDriver(new Uri("http://192.168.1.107:4444"), options);
            driver.Manage().Window.Maximize();
            return driver;
        }
    }
}
