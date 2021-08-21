using OpenQA.Selenium;

namespace MovieStoreWebApp.Test.Pages
{
    public class DeleteMoviePage : MovieStorePage
    {
        public DeleteMoviePage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement TitleDescription => _driver.FindElement(By.XPath("/html/body/div/main/div/dl/dd[1]"));

        private IWebElement DeleteButton => _driver.FindElement(By.Id("submit-form"));

        public bool VerifyMovie(string title) => TitleDescription.Text == title;

        public MoviesPage ClickDeleteButton()
        {
            DeleteButton.Click();
            return new MoviesPage(_driver);
        }
    }
}
