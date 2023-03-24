﻿using Microsoft.Data.SqlClient;

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
        }
            public void GetProduct(Product p)
            { 
                SqlCommand sqlCommand = new SqlCommand($"SELECT * FROM dbo.Products WHERE (ProductId={p.productId})"); 
            }
            public  void InsertProduct(Product p)
            {
                SqlCommand insert = new SqlCommand($"INSERT INTO dbo.Products VALUES (Name='{p.name}', PurchasePrice='{p.purchasePrice}', SalesPrice='{p.salesPrice}', Location='{p.location}', AmountInStock='{p.amountInStock}', Unit='{p.unit}')");
            }
            public  void UpdateProduct(Product p)
            {
                
                SqlCommand update = new SqlCommand($"UPDATE dbo.Products (ProductId,Name,PurchasePrice,SalesPrice,Location,AmountInStock,Unit) SET (Name='{p.name}', PurchasePrice='{p.purchasePrice}', SalesPrice='{p.salesPrice}', Location='{p.location}', AmountInStock='{p.amountInStock}', Unit='{p.unit}') WHERE (ProdictId = {p.productId})");

            }
            public  void DeleteProduct(Product p)
            {
                SqlCommand delete = new SqlCommand($"DELETE FROM dbo.Products WHERE (ProductId = {p.productId})");
            }
        }
    }

