using OpenQA.Selenium;

namespace MovieStoryWebApp.Test.Utils.Pages
{
    public class NavigationBar
    {
        private readonly IWebDriver _driver;

        public NavigationBar(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement HomeLink => _driver.FindElement(By.LinkText("Home"));

        public IWebElement MoviesLink => _driver.FindElement(By.LinkText("Movies"));

        public IWebElement PrivacyLink => _driver.FindElement(By.LinkText("Privacy"));

        public HomePage ClickHomeLink()
        {
            HomeLink.Click();
            return new HomePage(_driver);
        }

        public MoviesPage ClickMoviesLink()
        {
            MoviesLink.Click();
            return new MoviesPage(_driver);
        }

        public PrivacyPage ClickPrivacyLink()
        {
            PrivacyLink.Click();
            return new PrivacyPage(_driver);
        }
    }
}
