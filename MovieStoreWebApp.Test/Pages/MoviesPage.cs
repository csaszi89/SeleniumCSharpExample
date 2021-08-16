using MovieStoreWebApp.Test.Attributes;
using OpenQA.Selenium;

namespace MovieStoreWebApp.Test.Pages
{
    [Url("Movies")]
    [Title("Movies")]
    public class MoviesPage : MovieStorePage
    {
        public MoviesPage(IWebDriver driver) : base(driver)
        {
        }
    }
}
