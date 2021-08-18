using System;

namespace MovieStoreWebApp.Test.Utils
{
    public static class TestData
    {
        public static class Movies
        {
            public static (string Title, DateTime ReleaseDate, string Genre, decimal Price, string Rating) TheHangover = ("The Hangover", new DateTime(2009, 6, 18), "Comedy", 9.99m, "R");
        }
    }
}
