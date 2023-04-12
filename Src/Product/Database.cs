using Microsoft.Data.SqlClient;


namespace App
{
    public partial class Database
    {
        public List<Product> GetProducts(string productId)
        {
            string queryString = "";
            if (productId.Length > 0)
            {
                queryString = $"SELECT * FROM dbo.Products WHERE Id LIKE '{productId}'";
            }
            else
            {
                queryString = $"SELECT * FROM dbo.Products";
            }

            SqlCommand command = new SqlCommand(queryString, this.connection);

            command.ExecuteNonQuery();

            List<Product> products = new List<Product>();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {

                    App.Unit unit;
                    Enum.TryParse<App.Unit>(Convert.ToString(reader[6]), out unit);

                    products.Add(new Product(
                                    Convert.ToString(reader[1]),
                                    Convert.ToDouble(reader[2]),
                                    Convert.ToDouble(reader[3]),
                                    Convert.ToString(reader[4]),
                                    Convert.ToInt32(reader[5]),
                                    unit));
                }
            }
            return products;
        }

        public void InsertProduct(Product product)
        {
            string queryString = $"INSERT INTO dbo.Products VALUES ('{product.name}', '{product.purchasePrice}', '{product.salesPrice}', '{product.location}', '{product.amountInStock}', '{product.unit}')";

            SqlCommand command = new SqlCommand(queryString, this.connection);

            command.ExecuteNonQuery();
        }

        public void UpdateProduct(Product product)
        {
            string queryString = $"UPDATE dbo.Products SET (Name='{product.name}', PurchasePrice='{product.purchasePrice}', SalesPrice='{product.salesPrice}', Location='{product.location}', AmountInStock='{product.amountInStock}', Unit='{product.unit}') WHERE ProdictId = {product.Id}";

            SqlCommand command = new SqlCommand(queryString, this.connection);

            command.ExecuteNonQuery();
        }

        public void DeleteProduct(Product product)
        {
            string queryString = $"DELETE FROM dbo.Products WHERE ProductId={product.Id}";

            SqlCommand command = new SqlCommand(queryString, this.connection);

            command.ExecuteNonQuery();
        }
    }
}

