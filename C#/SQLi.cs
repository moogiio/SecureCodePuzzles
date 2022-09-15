using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CSharp.Controllers
{
    [Route("api/sql")]
    public class SqlInjectionController : Controller
    {

        private readonly IConfiguration _configuration;
        public SqlInjectionController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("user")]
        public string GetNonSensitiveDataById()
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetValue<string>("ConnectionString")))
            {
                int id = int.Parse(Request.Query["id"]);
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Users WHERE Id = " + id, connection);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string returnString = string.Empty;
                        returnString += "Name :" + reader["Name"] + ". ";
                        returnString += "Description : " + reader["Description"];
                        return returnString;
                    }
                    else
                    {
                        return string.Empty;
                    }
                }
            }
        }

        [HttpGet]
        [Route("userparam")]
        public string GetNonSensitiveDataByNameWithParam()
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetValue<string>("ConnectionString")))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Users WHERE Name = @name", connection);
                command.Parameters.AddWithValue("@name", Request.Query["name"].ToString());
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string returnString = string.Empty;
                        returnString += "Name : " + reader["Name"] + ". ";
                        returnString += "Description : " + reader["Description"];
                        return returnString;
                    }
                    else
                    {
                        return string.Empty;
                    }
                }
            }
        }
    }
}
