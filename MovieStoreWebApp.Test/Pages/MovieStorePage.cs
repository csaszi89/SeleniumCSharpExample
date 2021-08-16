﻿using MovieStoreWebApp.Test.Attributes;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace MovieStoreWebApp.Test.Pages
{
    public abstract class MovieStorePage
    {
        private readonly TimeSpan _pageLoadTimeout = TimeSpan.FromSeconds(3);
        protected readonly IWebDriver _driver;

        /// <summary>
        /// Ctor for UI Automation tests
        /// </summary>
        protected MovieStorePage()
        {
        }

        protected MovieStorePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public const string UrlConstant = "https://localhost:5001";

        public const string TitleConstant = "MovieStore";

        public virtual string Url => $"{UrlConstant}/{((UrlAttribute)Attribute.GetCustomAttribute(GetType(), typeof(UrlAttribute))).Url}";

        public virtual string Title => $"{((TitleAttribute)Attribute.GetCustomAttribute(GetType(), typeof(TitleAttribute))).Title} - {TitleConstant}";

        /// <summary>
        /// Navigates to the page and waits till the url and title are okay.
        /// </summary>
        /// <returns></returns>
        public virtual bool NavigateTo()
        {
            _driver.Navigate().GoToUrl(Url);
            var wait = new WebDriverWait(_driver, _pageLoadTimeout);

            try
            {
                return wait.Until(ExpectedConditions.UrlToBe(Url)) && wait.Until(ExpectedConditions.TitleIs(Title));
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        public virtual bool NavigateTo<T>(IWebElement navigationElement, out T result) where T : MovieStorePage
        {
            navigationElement.Click();
            result = (T)Activator.CreateInstance(typeof(T), _driver);
            var wait = new WebDriverWait(_driver, _pageLoadTimeout);

            try
            {
                return wait.Until(ExpectedConditions.UrlToBe(result.Url)) && wait.Until(ExpectedConditions.TitleIs(result.Title));
            }
            catch (WebDriverTimeoutException)
            {
                result = null;
                return false;
            }
        }
    }
}
