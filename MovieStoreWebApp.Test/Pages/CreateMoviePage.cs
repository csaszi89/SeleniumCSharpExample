using OpenQA.Selenium;
using System;
using System.Globalization;
using WindowsInput;

namespace MovieStoreWebApp.Test.Pages
{
    public class CreateMoviePage : MovieStorePage
    {
        public CreateMoviePage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement TitleInput => _driver.FindElement(By.Id("Movie_Title"));

        public IWebElement ReleaseDateInput => _driver.FindElement(By.Id("Movie_ReleaseDate"));

        public IWebElement GenreInput => _driver.FindElement(By.Id("Movie_Genre"));

        public IWebElement PriceInput => _driver.FindElement(By.Id("Movie_Price"));

        public IWebElement RatingInput => _driver.FindElement(By.Id("Movie_Rating"));

        public IWebElement SubmitButton => _driver.FindElement(By.Id("submit-form"));

        public void CreateNewMovie((string Title, DateTime ReleaseDate, string Genre, decimal Price, string Rating) movie)
        {
            InputSimulator sim = new InputSimulator();
            TitleInput.SendKeys(movie.Title);
            ReleaseDateInput.SendKeys(movie.ReleaseDate.Year.ToString());
            sim.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.RIGHT);
            ReleaseDateInput.SendKeys(movie.ReleaseDate.Month.ToString());
            ReleaseDateInput.SendKeys(movie.ReleaseDate.Day.ToString());
            GenreInput.SendKeys(movie.Genre);
            PriceInput.SendKeys(movie.Price.ToString(CultureInfo.InvariantCulture));
            RatingInput.SendKeys(movie.Rating);
            SubmitButton.Click();
        }
    }
}
