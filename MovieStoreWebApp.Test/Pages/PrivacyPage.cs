using MovieStoreWebApp.Test.Attributes;
using OpenQA.Selenium;

namespace MovieStoreWebApp.Test.Pages
{
    [Url("Privacy")]
    [Title("Privacy Policy")]
    [H1("Privacy Policy")]
    public class PrivacyPage : MovieStorePage
    {
        public PrivacyPage(IWebDriver driver) : base(driver)
        {
        }
    }
}
