
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using YinlongWeb.Models;

namespace YinlongWeb.Services
{
    public class CommentDAO : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public List<CommentModel> GetAllComments()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.DataSource = "ylsqlserver.database.windows.net";
            builder.UserID = "Enter My Db User";
            builder.Password = "Enter Password";
            builder.InitialCatalog = "mySampleDatabase";

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                List<CommentModel> foundComments = new List<CommentModel>();

                connection.Open();

                String sql = "SELECT * FROM dbo.Comment";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            foundComments.Add(new CommentModel { Id = (int)reader[0], Name = (string)reader[1], Country = (string)reader[2], Comment = (string)reader[3] });
                        }
                    }
                }
           

                return foundComments;

            }
        }




        public int Insert(CommentModel comments)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.DataSource = "ylsqlserver.database.windows.net";
            builder.UserID = "Enter My Db User";
            builder.Password = "Enter Password";
            builder.InitialCatalog = "mySampleDatabase";

                int newIdNumber = comments.Id;
            string sqlStatement = "INSERT INTO dbo.Comment(Name, Country, Comment) VALUES(@Name, @Country, @Comment)";


            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {

                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@Name", comments.Name);
                command.Parameters.AddWithValue("@Country", comments.Country);
                command.Parameters.AddWithValue("@Comment", comments.Comment);
                

                connection.Open();
                int result = command.ExecuteNonQuery();

                // Check Error
                if (result < 0)
                    Console.WriteLine("Error inserting data into Database!");


            }

            return newIdNumber;
        }



    }
}
