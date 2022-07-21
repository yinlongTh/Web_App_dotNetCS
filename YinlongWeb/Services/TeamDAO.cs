using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using YinlongWeb.Models;

namespace YinlongWeb.Services
{
    public class TeamDAO
    {

        public TeamModel GetMemberById(int id)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.DataSource = "ylsqlserver.database.windows.net";
            builder.UserID = "Enter My Db User";
            builder.Password = "Enter Password";
            builder.InitialCatalog = "mySampleDatabase";

            TeamModel foundMember = new TeamModel();
            string sqlStatement = "SELECT * FROM dbo.Team WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    foundMember = new TeamModel { Id = (int)reader[0], Name = (string)reader[1], Position = (string)reader[2], Country = (string)reader[3], Description = (string)reader[4] };

                }


            }

            return foundMember;
        }

        public List<TeamModel> GetAllMembers()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.DataSource = "ylsqlserver.database.windows.net";
            builder.UserID = "Enter My Db User";
            builder.Password = "Enter Password";
            builder.InitialCatalog = "mySampleDatabase";

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                List<TeamModel> foundMembers = new List<TeamModel>();

                connection.Open();

                String sql = "SELECT * FROM dbo.Team";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            foundMembers.Add(new TeamModel { Id = (int)reader[0], Name = (string)reader[1], Position = (string)reader[2], Country = (string)reader[3], Description = (string)reader[4] });
                        }
                    }
                }

                return foundMembers;

            }
        }

    }
}
