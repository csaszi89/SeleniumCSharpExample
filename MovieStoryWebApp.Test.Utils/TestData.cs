using MovieStoryWebApp.Test.Utils.Models;
using System;

namespace MovieStoreWebApp.Test.Utils
{
    public static class TestData
    {
        public static class Movies
        {
            public static Movie TheHangover = new Movie { Title = "The Hangover", ReleaseDate = new DateTime(2009, 6, 18), Genre = "Comedy", Price = 9.99m, Rating = "R" };
            public static Movie Titanic = new Movie { Title = "Titanic", ReleaseDate = new DateTime(1998, 1, 22), Genre = "Drama", Price = 7.99m, Rating = "PG" };
        }
    }
}
