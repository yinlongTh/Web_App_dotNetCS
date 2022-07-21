using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using YinlongWeb.Models;

namespace YinlongWeb.Services
{
    public class SkillDAO
    {

        public List<SkillModel> GetAllSkills()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.DataSource = "ylsqlserver.database.windows.net";
            builder.UserID = "Enter My Db User";
            builder.Password = "Enter Password";
            builder.InitialCatalog = "mySampleDatabase";

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                List<SkillModel> foundSkills = new List<SkillModel>();

                connection.Open();

                String sql = "SELECT * FROM dbo.Skills";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            foundSkills.Add(new SkillModel { Id = (int)reader[0], Skill = (string)reader[1], Platform = (string)reader[2], Description = (string)reader[3] });
                        }
                    }
                }

                return foundSkills;

            }
        }

    }
}

