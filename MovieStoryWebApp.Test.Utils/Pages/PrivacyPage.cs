using MovieStoreWebApp.Test.Utils.Attributes;
using OpenQA.Selenium;

namespace MovieStoreWebApp.Test.Utils.Pages
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
