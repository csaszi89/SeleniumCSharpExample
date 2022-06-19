using MovieStoryWebApp.Test.Utils.Attributes;
using OpenQA.Selenium;

namespace MovieStoryWebApp.Test.Utils.Pages
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
