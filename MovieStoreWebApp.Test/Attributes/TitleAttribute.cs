using MovieStoreWebApp.Test.Utils;
using System;

namespace MovieStoreWebApp.Test.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class TitleAttribute : Attribute
    {
        public TitleAttribute(string title)
        {
            Argument.VerifyNotNull(title);
            Title = title;
        }

        public string Title { get; }
    }
}
