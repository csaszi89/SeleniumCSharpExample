using MovieStoreWebApp.Test.Utils;
using System.Data.SqlClient;

namespace MovieStoreWebApp.Test.Helpers
{
    public static class DBHelper
    {
        public static void DeleteMovie(string title)
        {
            string sqlCommand = "DELETE FROM " + "dbo.Movie" + " WHERE " + "Title" + " = '" + title + "'";

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand(sqlCommand, con))
                {
                    _ = command.ExecuteNonQuery();
                }
                con.Close();
            }
        }
    }
}
