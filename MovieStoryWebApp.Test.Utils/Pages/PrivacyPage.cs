using MovieStoryWebApp.Test.Utils.Attributes;
using OpenQA.Selenium;

namespace MovieStoryWebApp.Test.Utils.Pages
{
    [Url("Privacy")]
    [Title("Privacy Policy")]
    [H1("Privacy Policy")]
    public class PrivacyPage : MovieStorePage
    {
        public PrivacyPage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement P => _driver.FindElement(By.TagName("p"));
    }
}
