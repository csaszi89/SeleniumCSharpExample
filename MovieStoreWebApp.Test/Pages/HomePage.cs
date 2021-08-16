using MovieStoreWebApp.Test.Attributes;
using OpenQA.Selenium;

namespace MovieStoreWebApp.Test.Pages
{
    [Url("")]
    [Title("Home page")]
    public class HomePage : MovieStorePage
    {
        public const string MoviesLinkText = "Movies";
        public const string PrivacyLinkText = "Privacy";

        /// <summary>
        /// Ctor for UI Automation tests
        /// </summary>
        public HomePage()
        {
        }

        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement MoviesLink => _driver.FindElement(By.LinkText(MoviesLinkText));

        public IWebElement PrivacyLink => _driver.FindElement(By.LinkText(PrivacyLinkText));
    }
}
