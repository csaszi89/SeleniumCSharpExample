using MovieStoreWebApp.Test.Attributes;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace MovieStoreWebApp.Test.Pages
{
    [Url("Movies")]
    [Title("Movies")]
    public class MoviesPage : MovieStorePage
    {
        public MoviesPage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement CreateNewLink => _driver.FindElement(By.LinkText("Create New"));

        public IEnumerable<string> Movies => _driver.FindElement(By.TagName("tbody")).FindElements(By.TagName("tr")).Select(row => row.FindElement(By.TagName("td")).Text);

        public CreateMoviePage ClickCreateNewLink()
        {
            CreateNewLink.Click();
            return new CreateMoviePage(_driver);
        }
    }
}
