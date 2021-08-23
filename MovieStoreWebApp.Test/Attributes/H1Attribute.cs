using MovieStoreWebApp.Test.Utils;
using System;

namespace MovieStoreWebApp.Test.Attributes
{
    public class H1Attribute : Attribute
    {
        public H1Attribute(string h1)
        {
            Argument.VerifyNotNull(h1);
            H1 = h1;
        }

        public string H1 { get; }
    }
}
