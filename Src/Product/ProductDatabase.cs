using Microsoft.Data.SqlClient;

namespace App
{
    partial class Database
    {
        public void GetProducts()
        {
            string queryString = "SELECT * FROM dbo.Products";
            using (SqlConnection connection = new SqlConnection(this.connectionStr))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(String.Format($"{reader[0]}, {reader[1]}"));
                    }
                    connection.Close();
                }
            }
        }
    }
}
