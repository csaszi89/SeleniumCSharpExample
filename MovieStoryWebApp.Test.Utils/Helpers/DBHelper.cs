using System;
using System.Data.SqlClient;

namespace MovieStoryWebApp.Test.Utils.Helpers
{
    public static class DBHelper
    {
        public static void AddMovie((string Title, DateTime ReleaseDate, string Genre, decimal Price, string Rating) movie)
        {
            string sql = "INSERT INTO dbo.Movie (Title,ReleaseDate,Genre,Price,Rating) VALUES (@val1, @val2, @val3, @val4, @val5)";
            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = con;
                    command.CommandText = sql;
                    command.Parameters.AddWithValue("@val1", movie.Title);
                    command.Parameters.AddWithValue("@val2", movie.ReleaseDate);
                    command.Parameters.AddWithValue("@val3", movie.Genre);
                    command.Parameters.AddWithValue("@val4", movie.Price);
                    command.Parameters.AddWithValue("@val5", movie.Rating);
                    _ = command.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public static void DeleteMovie(string title)
        {
            string sql = "DELETE FROM " + "dbo.Movie" + " WHERE " + "Title" + " = '" + title + "'";
            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    _ = command.ExecuteNonQuery();
                }
                con.Close();
            }
        }
    }
}
