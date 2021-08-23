using MovieStoreWebApp.Test.Utils;
using System;

namespace MovieStoreWebApp.Test.Attributes
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
