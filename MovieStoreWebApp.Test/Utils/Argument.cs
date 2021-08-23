using System;

namespace MovieStoreWebApp.Test.Utils
{
    public static class Argument
    {
        public static void VerifyNotNull(object arg)
        {
            if (arg == null)
            {
                throw new ArgumentNullException("Argument is null");
            }
        }
    }
}
