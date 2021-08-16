using MovieStoreWebApp.Test.Pages;
using OpenQA.Selenium;
using System;

namespace MovieStoreWebApp.Test.Extensions
{
    public static class IWebDriverExtensions
    {
        public static T NavigateTo<T>(this IWebDriver driver) where T : MovieStorePage
        {
            var result = (T)Activator.CreateInstance(typeof(T), driver);
            driver.Navigate().GoToUrl(result.Url);
            return result;
        }
    }
}
