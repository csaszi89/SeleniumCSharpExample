using MovieStoreWebApp.Test.Utils.Attributes;
using OpenQA.Selenium;

namespace MovieStoreWebApp.Test.Utils.Pages
{
    [Url("")]
    [Title("Home")]
    [H1("Welcome")]
    public class HomePage : MovieStorePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement P => _driver.FindElement(By.TagName("p"));
    }
}
