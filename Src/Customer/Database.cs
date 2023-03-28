using Microsoft.Data.SqlClient;
using Newtonsoft.Json;

namespace App
{
    public partial class Database
    {
        //Get one customer same as ID
        public List<CustomerList> GetCustomer(uint customerID)
        {
            string queryString = $"SELECT * FROM dbo.Customers WHERE (CustomerID = {customerID})";

            SqlCommand command = new SqlCommand(queryString, connection);

            command.ExecuteNonQuery();

            List<CustomerList> customer = new List<CustomerList> { };

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    customer.Add(new CustomerList(
                        Convert.ToUInt32(reader[0]),
                        Convert.ToString(reader[1]),
                        Convert.ToString(reader[2]),
                        Convert.ToString(reader[3])
                        ));
                }
            }
            return customer;
        }

        //Get alle customers
        public List<CustomerList> GetCustomers()
        {
            string queryString = "SELECT * FROM dbo.Customers";

            SqlCommand command = new SqlCommand(queryString, this.connection);

            command.ExecuteNonQuery();

            List<CustomerList> customer = new List<CustomerList> { };

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    customer.Add(new CustomerList(
                        Convert.ToUInt32(reader[0]),
                        Convert.ToString(reader[1]),
                        Convert.ToString(reader[2]),
                        Convert.ToString(reader[3])
                        ));
                }
            }
            return customer;
        }


        //Add Customer
        public void InsertOrder(CustomerList customer)
        {
            string queryString = $"INSERT INTO dbo.Customers VALUES ('{customer.CustomerID}', '{customer.CustomerFullName}', '{customer.CustomerPhone}', '{customer.CustomerMail}'";

            SqlCommand command = new SqlCommand(queryString, this.connection);

            command.ExecuteNonQuery();
        }

        //Update Customer
        public void UpdateOrder(CustomerList customer)
        {
            string queryString = $"UPDATE dbo.Customers SET (CustomerFullName='{customer.CustomerFullName}', CustomerPhone='{customer.CustomerPhone}', State='{customer.CustomerMail}', WHERE OrderNumber={customer.CustomerID}";

            SqlCommand command = new SqlCommand(queryString, this.connection);

            command.ExecuteNonQuery();
        }

        //Delete Customer
        public void DeleteOrder(CustomerList customer)
        {
            string queryString = $"DELETE FROM dbo.Customers WHERE OrderNumber={customer.CustomerID}";

            SqlCommand command = new SqlCommand(queryString, this.connection);

            command.ExecuteNonQuery();
        }
    }
}