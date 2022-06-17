using MovieStoryWebApp.Test.Utils.Attributes;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace MovieStoryWebApp.Test.Utils.Pages
{
    public abstract class MovieStorePage
    {
        private readonly TimeSpan _pageLoadTimeout = TimeSpan.FromSeconds(3);
        protected readonly IWebDriver _driver;

        protected MovieStorePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public const string UrlConstant = "https://localhost:5001";

        public const string TitleConstant = "MovieStore";

        public virtual string Url => $"{UrlConstant}/{((UrlAttribute)Attribute.GetCustomAttribute(GetType(), typeof(UrlAttribute))).Url}";

        public virtual string Title => $"{((TitleAttribute)Attribute.GetCustomAttribute(GetType(), typeof(TitleAttribute))).Title} - {TitleConstant}";

        public virtual string H1 => $"{((H1Attribute)Attribute.GetCustomAttribute(GetType(), typeof(H1Attribute))).H1}";

        public virtual bool Verify()
        {
            try
            {
                var wait = new WebDriverWait(_driver, _pageLoadTimeout);
                return wait.Until(ExpectedConditions.UrlToBe(Url)) && wait.Until(ExpectedConditions.TitleIs(Title)) && wait.Until((driver) => driver.FindElement(By.TagName("h1")).Text == H1);
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }
    }
}
