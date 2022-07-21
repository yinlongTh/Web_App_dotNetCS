
using System.Data.SqlClient;
using YinlongWeb.Models;

namespace YinlongWeb.Services
{
    public class Userdao
    {
      
        public bool FindUserByNameAndPassword(UserModel user)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.DataSource = "ylsqlserver.database.windows.net";
            builder.UserID = "Enter My Db User";
            builder.Password = "Enter Password";
            builder.InitialCatalog = "mySampleDatabase";

            bool success = false;

            string sql = "SELECT * FROM dbo.logininfo WHERE Username = @username AND Password = @password";
            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.Add("@username", System.Data.SqlDbType.VarChar, 40).Value = user.UserName;
                command.Parameters.Add("@password", System.Data.SqlDbType.VarChar, 40).Value = user.MyPassword;


                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    success = true;

                }

            }

            return success;
        }

        public bool Insert(UserModel user)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.DataSource = "ylsqlserver.database.windows.net";
            builder.UserID = "Enter My Db User";
            builder.Password = "Enter Password";
            builder.InitialCatalog = "mySampleDatabase";

            bool success = false;
            
            string sql = "INSERT INTO dbo.logininfo(Username, Password) VALUES(@Name, @Password)";
            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);

                
                command.Parameters.AddWithValue("@Name", user.UserName);
                command.Parameters.AddWithValue("@Password", user.MyPassword);

                connection.Open();
           
                int result = command.ExecuteNonQuery();

                // Check Error
                if (result < 0)
                    Console.WriteLine("Error inserting data into Database!");



            }

            return success;

        }

    }
}
