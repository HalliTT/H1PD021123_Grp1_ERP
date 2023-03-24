using Microsoft.Data.SqlClient;

namespace App
{
    public partial class Database
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
            static void InsertProduct(Product p)
            {
                SqlCommand insert = new SqlCommand("INSERT INTO dbo.Products (ProductId,Name,PurchasePrice,SalesPrice,Location,AmountInStock,Unit) VALUES (1,'Name', 1.2, 200.0, 'locationstf', 1.2, 'meter')");
            }
            static void UpdateProduct(Product p)
            {

                SqlCommand update = new SqlCommand("UPDATE dbo.Products (ProductId,Name,PurchasePrice,SalesPrice,Location,AmountInStock,Unit) SET (1,'Name', 1.2, 200.0, 'locationstf', 1.2, 'meter') WHERE (ProdictId = 1)");

            }
            static void DeleteProduct(Product p)
            {
                SqlCommand delete = new SqlCommand("DELETE FROM dbo.Products (ProductId,Name,PurchasePrice,SalesPrice,Location,AmountInStock,Unit) WHERE (ProductId = 1)");
            }
        }
    }
}
