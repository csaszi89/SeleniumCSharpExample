using MovieStoryWebApp.Test.Utils.Attributes;
using OpenQA.Selenium;
using System;
using System.Globalization;

namespace MovieStoryWebApp.Test.Utils.Pages
{
    [Url("Movies/Create")]
    [Title("Create")]
    [H1("Create")]
    public class CreateMoviePage : MovieStorePage
    {
        public CreateMoviePage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement TitleInput => _driver.FindElement(By.Id("Movie_Title"));

        private IWebElement ReleaseDateInput => _driver.FindElement(By.Id("Movie_ReleaseDate"));

        private IWebElement GenreInput => _driver.FindElement(By.Id("Movie_Genre"));

        private IWebElement PriceInput => _driver.FindElement(By.Id("Movie_Price"));

        private IWebElement RatingInput => _driver.FindElement(By.Id("Movie_Rating"));

        private IWebElement CreateButton => _driver.FindElement(By.Id("submit-form"));

        public MoviesPage CreateNewMovie((string Title, DateTime ReleaseDate, string Genre, decimal Price, string Rating) movie)
        {
            TitleInput.SendKeys(movie.Title);
            ReleaseDateInput.SendKeys(movie.ReleaseDate.Year.ToString());
            ReleaseDateInput.SendKeys(Keys.Right);
            ReleaseDateInput.SendKeys(movie.ReleaseDate.Month.ToString());
            ReleaseDateInput.SendKeys(movie.ReleaseDate.Day.ToString());
            GenreInput.SendKeys(movie.Genre);
            PriceInput.SendKeys(movie.Price.ToString(CultureInfo.InvariantCulture));
            RatingInput.SendKeys(movie.Rating);
            CreateButton.Click();
            return new MoviesPage(_driver);
        }
    }
}
