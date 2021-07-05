using MovieStoreWebApp.Test.Attributes;
using OpenQA.Selenium;
using System;

namespace MovieStoreWebApp.Test.Pages
{
    public abstract class MovieStorePage
    {
        protected const string UrlConstant = "https://localhost:5001";

        protected const string TitleConstant = "MovieStore";

        public virtual string Url => $"{UrlConstant}/{((UrlAttribute)Attribute.GetCustomAttribute(GetType(), typeof(UrlAttribute))).Url}";

        public virtual string Title => $"{((TitleAttribute)Attribute.GetCustomAttribute(GetType(), typeof(TitleAttribute))).Title} - {TitleConstant}";

        public virtual bool Verify(IWebDriver browser) => browser.Url == Url && browser.Title == Title;
    }
}
