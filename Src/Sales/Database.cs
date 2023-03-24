using Microsoft.Data.SqlClient;

namespace App
{
    public partial class Database
    {
        public void GetOrder(string id)
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

        public void GetOrders()
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

        public void SetOrder(Sales order)
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

        public void UpdateOrder(int id)
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

        public void DeleteOrder(int id)
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