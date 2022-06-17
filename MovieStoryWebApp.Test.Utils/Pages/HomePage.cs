using MovieStoryWebApp.Test.Utils.Attributes;
using OpenQA.Selenium;

namespace MovieStoryWebApp.Test.Utils.Pages
{
    [Url("")]
    [Title("Home")]
    [H1("Welcome")]
    public class HomePage : MovieStorePage
    {
        public const string MoviesLinkText = "Movies";
        public const string PrivacyLinkText = "Privacy";

        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement MoviesLink => _driver.FindElement(By.LinkText(MoviesLinkText));

        public IWebElement PrivacyLink => _driver.FindElement(By.LinkText(PrivacyLinkText));

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
