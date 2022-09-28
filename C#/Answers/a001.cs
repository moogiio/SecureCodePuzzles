[HttpGet]
[Route("user")]
public string GetNonSensitiveDataById()
{
    using (SqlConnection connection = new SqlConnection(_configuration.GetValue<string>("ConnectionString")))
    {
        int id = int.Parse(Request.Query["id"]);
        connection.Open();
        SqlCommand command = new SqlCommand("SELECT * FROM Users WHERE Id = " + id, connection); // Parse request to an int to prevent SQLi, but still prone to information leakage
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
        SqlCommand command = new SqlCommand("SELECT * FROM Users WHERE Name = @name", connection); // Parameterize query to prevent SQLi, but still prone to information leakage
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