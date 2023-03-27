using Microsoft.Data.SqlClient;

namespace App
{
    public partial class Database
    {
        public List<Product> GetProducts()
        {
            string queryString = "SELECT * FROM dbo.Products";

            SqlCommand command = new SqlCommand(queryString, this.connection);

            command.ExecuteNonQuery();

            List<Product> products = new List<Product>();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    // Console.WriteLine(String.Format($"{reader[0]}, {reader[1]}"));
                }
            }
            return products;
        }
        public void GetProduct(Product p)
            {
                string queryString = $"SELECT * FROM dbo.Products WHERE (ProductId={p.productId})";

                SqlCommand command = new SqlCommand(queryString,this.connection);
                
                command.ExecuteNonQuery();
                
                List<Product> product = new List<Product> {};
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    App.Unit unit;
                    Enum.TryParse<App.Unit>(Convert.ToString(reader[6]), out unit);

                    new List<Product> { new Product(Convert.ToString(reader[0]), Convert.ToString(reader[1]), Convert.ToDouble(reader[2]), Convert.ToDouble(reader[3]), Convert.ToString(reader[4]), Convert.ToInt64(reader[5]), unit)};
                }
             }
    }
            public  void InsertProduct(Product p)
            {
                string queryString = $"INSERT INTO dbo.Products VALUES (Name='{p.name}', PurchasePrice='{p.purchasePrice}', SalesPrice='{p.salesPrice}', Location='{p.location}', AmountInStock='{p.amountInStock}', Unit='{p.unit}')";
                
                SqlCommand command = new SqlCommand(queryString, this.connection);
                 
                command.ExecuteNonQuery();
            }
            public  void UpdateProduct(Product p)
            {
            string queryString = $"UPDATE dbo.Products (ProductId,Name,PurchasePrice,SalesPrice,Location,AmountInStock,Unit) SET (Name='{p.name}', PurchasePrice='{p.purchasePrice}', SalesPrice='{p.salesPrice}', Location='{p.location}', AmountInStock='{p.amountInStock}', Unit='{p.unit}') WHERE (ProdictId = {p.productId})";
           
            SqlCommand command = new SqlCommand(queryString, this.connection);

            command.ExecuteNonQuery();

            }
            public  void DeleteProduct(Product p)
            {
             string queryString = $"DELETE FROM dbo.Products WHERE(ProductId = { p.productId})";
                
             SqlCommand command = new SqlCommand(queryString, this.connection);

             command.ExecuteNonQuery();
            }
        }
}
