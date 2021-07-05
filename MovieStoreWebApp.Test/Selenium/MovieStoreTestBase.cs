using MovieStoreWebApp.Test.Definitions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;

namespace MovieStoreWebApp.Test.Selenium
{
    public class MovieStoreTestBase
    {
        protected IWebDriver StartBrowser(BrowserType browserType)
        {
            if (browserType == BrowserType.Chrome)
            {
                var chromeOptions = new ChromeOptions();
                chromeOptions.AddArgument("--start-maximized");
                return new ChromeDriver(ChromeDriverService.CreateDefaultService(AppDomain.CurrentDomain.BaseDirectory, FileNames.ChromeDriverExecutable), chromeOptions);
            }
            if (browserType == BrowserType.MicrosoftEdge)
            {
                var driver = new EdgeDriver(EdgeDriverService.CreateDefaultService(AppDomain.CurrentDomain.BaseDirectory, FileNames.EdgeDriverExecutable));
                driver.Manage().Window.Maximize();
                return driver;
            }
            // Other browsers here...
            throw new NotSupportedException($"Browser type {browserType} not supported");
        }
    }
}
