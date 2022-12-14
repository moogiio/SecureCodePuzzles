/*
    Answer 01
*/

[HttpGet]
[Route("user")]
public string GetDataById()
{
    using (SqlConnection connection = new SqlConnection(_configuration.GetValue<string>("ConnectionString")))
    {
        int id = int.Parse(Request.Query["id"]);
        connection.Open();
        SqlCommand command = new SqlCommand("SELECT * FROM Users WHERE Id = " + id, connection); // Parse request to an int to prevent SQLi
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

/*
    Answer 2
*/

[HttpGet]
[Route("userparam")]
public string GetDataWithParam()
{
    using (SqlConnection connection = new SqlConnection(_configuration.GetValue<string>("ConnectionString")))
    {
        connection.Open();
        SqlCommand command = new SqlCommand("SELECT * FROM Users WHERE Name = @name", connection); // Parameterize query to prevent SQLi
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