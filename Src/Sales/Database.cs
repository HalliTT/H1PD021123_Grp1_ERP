using System.Data;
using Microsoft.Data.SqlClient;
using SQLitePCL;

namespace App
{
    public partial class Database
    {
        public void InsertOrder(Sales order)
        {
            string queryString =
                $"INSERT INTO dbo.Orders VALUES ('{order.creationTimestamp}', '{order.doneTimestamp}', {order.customerId}, '{order.state.ToString()}', '{order.totalOrderPrice}')";
            // Order.
            SqlCommand command = new SqlCommand(queryString, _connection);

            var connection = new SqlConnection(ConnectionString);
            using (connection)
            {
                connection.Open();
                command.ExecuteNonQuery();
    
                queryString = "SELECT SCOPE_IDENTITY() FROM dbo.Orders";
    
                command = new SqlCommand(queryString, _connection);
    
                int IdScope = -1;
    
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        IdScope = Convert.ToInt32(reader[0]);
                    }
                }
    
                order.id = IdScope;
                            
            }
        }

        public List<OrderLine> GetOrderListPage(int orderId = 0, int productId = 0)
        {
            string queryString = "";
            if (orderId > 0 && productId <= 0)
            {
                queryString = $"SELECT * FROM dbo.OrdersListPage WHERE ordersId IS '{orderId}'";
            }
            else if (productId > 0 && orderId <= 0)
            {
                queryString = $"SELECT * FROM dbo.OrdersListPage WHERE ProductId IS '{productId}'";
            }
            var connection = new SqlConnection(ConnectionString);
            List<OrderLine> orderLines = new List<OrderLine> { };

            using (connection)
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                command.ExecuteNonQuery();


                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        orderLines.Add(new OrderLine(
                            Convert.ToInt32(reader[1]),
                            Convert.ToInt32(reader[2]),
                            Convert.ToInt32(reader[3])
                        ));
                    }
                }
            }
            return orderLines;
        }

        public List<Sales> GetOrder(int orderId = 0, int customerId = 0)
        {
            string queryString = "";
            if (orderId > 0 && customerId <= 0)
            {
                queryString = $"SELECT * FROM dbo.Orders WHERE Id LIKE '{orderId}'";
            }
            else if (customerId > 0 && orderId <= 0)
            {
                queryString = $"SELECT * FROM dbo.Orders WHERE CustomerId LIKE '{customerId}'";
            }
            else
            {
                queryString = $"SELECT * FROM dbo.Orders";
            }

            var connection = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand(queryString, connection);
            List<Sales> order = new List<Sales> { };
            
            using (connection)
            {
                connection.Open();
                command.ExecuteNonQuery();

                

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Trying to parse string to enum<State>
                        State state;
                        Enum.TryParse<State>(Convert.ToString(reader[4]), out state);

                        order.Add(new Sales(
                            Convert.ToString(reader[1]),
                            Convert.ToString(reader[2]),
                            Convert.ToInt32(reader[3]),
                            state,
                            Convert.ToUInt32(reader[5])));
                    }
                }
            }   
        

            return order;
        }


        public int InsertOrdersListPage(OrderLine line)
        {
            var connection = new SqlConnection(ConnectionString);
            using (connection)
            {
                string queryString =
                    $"INSERT INTO dbo.OrdersListPage VALUES ({line.ordersId}, {line.productId}, {line.amount})";

                SqlCommand command = new SqlCommand(queryString, connection);


                command.ExecuteNonQuery();

                queryString =
                    $"SELECT Id FROM dbo.OrdersListPage WHERE ordersId = {line.ordersId} AND productId = {line.ordersId}";

                command = new SqlCommand(queryString, connection);

                int Id = -1;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Id = Convert.ToInt32(reader[0]);
                    }

                    connection.Close();
                }

                return Id;
            }
        }

        public void UpdateOrder(Sales order)
        {
            string queryString = $"UPDATE dbo.Orders SET (DoneTimestamp='{order.doneTimestamp}', CustomerId={order.customerId}, State='{order.state.ToString()}', TotalOrderPrice='{order.totalOrderPrice}') WHERE Id={order.id}";

            var connection = new SqlConnection(ConnectionString);
            using (connection)
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }

        }

        public void DeleteOrder(Sales order)
        {
            var connection = new SqlConnection(ConnectionString);
            string queryString = $"DELETE FROM dbo.Orders WHERE Id={order.id}";
            using (connection)
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}