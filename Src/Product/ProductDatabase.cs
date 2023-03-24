using Microsoft.Data.SqlClient;

namespace App
{
    partial class Database
    {
        public void GetProducts()
        {
            string queryString = "SELECT * FROM dbo.Products";

                SqlCommand command = new SqlCommand(queryString, this.connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(String.Format($"{reader[0]}, {reader[1]}"));
                    }
                }
        }
    }
}
