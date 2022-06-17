using System;

namespace MovieStoryWebApp.Test.Utils.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class UrlAttribute : Attribute
    {
        public UrlAttribute(string url)
        {
            Argument.VerifyNotNull(url);
            Url = url;
        }

        public string Url { get; }
    }
}
