using MovieStoreWebApp.Test.Attributes;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace MovieStoreWebApp.Test.Pages
{
    [Url("Movies")]
    [Title("Movies")]
    public class MoviesPage : MovieStorePage
    {
        public MoviesPage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement CreateNewLink => _driver.FindElement(By.LinkText("Create New"));

        private IReadOnlyCollection<IWebElement> TableRows => _driver.FindElement(By.TagName("tbody")).FindElements(By.TagName("tr"));

        private IWebElement SearchInput => _driver.FindElement(By.Id("SearchString"));

        private IWebElement FilterButton => _driver.FindElement(By.XPath("//input[@value='Filter']"));

        public IEnumerable<string> Movies => TableRows.Select(row => row.FindElement(By.TagName("td")).Text);

        public CreateMoviePage ClickCreateNewLink()
        {
            CreateNewLink.Click();
            return new CreateMoviePage(_driver);
        }

        public void DeleteMovie(string title)
        {
            var movieRow = TableRows.First(row => row.FindElement(By.TagName("td")).Text == title);
            var deleteLink = movieRow.FindElement(By.LinkText("Delete"));
            deleteLink.Click();
            Thread.Sleep(500);
            var confirmation = _driver.SwitchTo().ActiveElement();
            var deleteButton = confirmation.FindElement(By.Id("deleteBtn"));
            deleteButton.Click();
        }

        public void SearchMovie(string searchTerm)
        {
            SearchInput.Clear();
            SearchInput.SendKeys(searchTerm);
            FilterButton.Click();
        }
    }
}
