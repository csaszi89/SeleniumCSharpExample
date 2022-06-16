﻿using MovieStoreWebApp.Test.Attributes;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieStoreWebApp.Test.Pages
{
    [Url("")]
    [Title("Details")]
    [H1("Details")]
    public class DetailsPage : MovieStorePage
    {
        public DetailsPage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement DataList => _driver.FindElement(By.TagName("dl"));

        public IReadOnlyCollection<IWebElement> MovieData => DataList.FindElements(By.TagName("dd"));

        public bool VerifyMovieDetails(string title) => MovieData.ToList()[0].Text.Trim() == title;
    }
}
