using Microsoft.Data.SqlClient;
using TECHCOOL.UI;


namespace App
{
    public partial class Database
    {
        public List<Product> GetProduct(int productId = 0)
        {
            string queryString = "";
            if (productId > 0)
            {
                queryString = $"SELECT * FROM dbo.Products WHERE Id LIKE '{productId}'";
            }
            else
            {
                queryString = $"SELECT * FROM dbo.Products";
            }

            SqlCommand command = new SqlCommand(queryString, _connection);

            connection.Open();
            command.ExecuteNonQuery();

                List<Product> products = new List<Product>();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        Unit unit;
                        Enum.TryParse<Unit>(Convert.ToString(reader[6]), out unit);

                        products.Add(new Product(
                            Convert.ToString(reader[1]),
                            Convert.ToString(reader[2]),
                            Convert.ToDouble(reader[3]),
                            Convert.ToDouble(reader[4]),
                            Convert.ToString(reader[5]),
                            Convert.ToDouble(reader[6]),
                            unit));
                    }
                }
                connection.Close();
                return products;
            }
        

        public void InsertProduct(Product product)
        {
            string queryString = $"INSERT INTO dbo.Products VALUES ('{product.name}', '{product.description}', '{product.purchasePrice}', '{product.salesPrice}', '{product.location}', '{product.amountInStock}', '{product.unit}')";

            SqlCommand command = new SqlCommand(queryString, _connection);

            command.ExecuteNonQuery();
        }

        public void UpdateProduct(Product product)
        {
            string queryString = $"UPDATE dbo.Products SET Name='{product.name}', PurchasePrice='{product.purchasePrice}', SalesPrice='{product.salesPrice}', Location='{product.location}', AmountInStock='{product.amountInStock}', Unit='{product.unit}' WHERE Id = {product.id}";

            SqlCommand command = new SqlCommand(queryString, _connection);

            command.ExecuteNonQuery();
        }

        public void DeleteProduct(Product product)
        {
            string queryString = $"DELETE FROM dbo.Products WHERE ProductId={product.id}";

            SqlCommand command = new SqlCommand(queryString, _connection);

            command.ExecuteNonQuery();
        }
    }
}

