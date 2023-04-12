using Microsoft.Data.SqlClient;
using Newtonsoft.Json;

namespace App
{
    public partial class Database
    {
        public List<OrderLine> GetOrderList(string orderId = "", string productId = "")
        {
            string queryString = "";
            if (orderId.Length > 0 && productId.Length <= 0)
            {
                queryString = $"SELECT * FROM dbo.OrdersList WHERE ordersId IS '{orderId}'";
            }
            else if (productId.Length > 0 && orderId.Length <= 0)
            {
                queryString = $"SELECT * FROM dbo.OrdersList WHERE ProductId IS '{productId}'";

            }

            SqlCommand command = new SqlCommand(queryString, connection);

            command.ExecuteNonQuery();

            List<OrderLine> orderLines = new List<OrderLine> { };

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
            return orderLines;
        }

        public List<Sales> GetOrder(string orderId = "", string customerId = "")
        {
            string queryString = "";
            if (orderId.Length > 0 && customerId.Length <= 0)
            {
                queryString = $"SELECT * FROM dbo.Orders WHERE Id LIKE '{orderId}'";
            }
            else if (customerId.Length > 0 && orderId.Length <= 0)
            {
                queryString = $"SELECT * FROM dbo.Orders WHERE CustomerId LIKE '{customerId}'";
            }
            else
            {
                queryString = $"SELECT * FROM dbo.Orders";
            }

            SqlCommand command = new SqlCommand(queryString, connection);

            command.ExecuteNonQuery();

            List<Sales> order = new List<Sales> { };

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    // Trying to parse string to enum<State>
                    App.State state;
                    Enum.TryParse<App.State>(Convert.ToString(reader[4]), out state);

                    order.Add(new Sales(
                                    Convert.ToString(reader[1]),
                                    Convert.ToString(reader[2]),
                                    Convert.ToInt32(reader[3]),
                                    state,
                                    Convert.ToUInt32(reader[5])));
                }
            }
            return order;
        }

        public void InsertOrder(Sales order)
        {
            string queryString = $"INSERT INTO dbo.Orders VALUES ('{order.creationTimestamp}', '{order.doneTimestamp}', '{order.customerId}', '{order.state.ToString()}', '{order.totalOrderPrice}')";

            SqlCommand command = new SqlCommand(queryString, this.connection);

            command.ExecuteNonQuery();
        }

        public void InsertOrdersList(OrderLine line)
        {
            string queryString = $"INSERT INTO dbo.OrdersList VALUES ('{line.ordersId}', '{line.productId}', '{line.amount}')";

            SqlCommand command = new SqlCommand(queryString, this.connection);

            command.ExecuteNonQuery();
        }



        public void UpdateOrder(Sales order)
        {
            string queryString = $"UPDATE dbo.Orders SET (DoneTimestamp='{order.doneTimestamp}', CustomerId='{order.customerId}', State='{order.state.ToString()}', TotalOrderPrice='{order.totalOrderPrice}') WHERE Id={order.Id}";

            SqlCommand command = new SqlCommand(queryString, this.connection);

            command.ExecuteNonQuery();
        }

        public void DeleteOrder(Sales order)
        {
            string queryString = $"DELETE FROM dbo.Orders WHERE Id={order.Id}";

            SqlCommand command = new SqlCommand(queryString, this.connection);

            command.ExecuteNonQuery();
        }
    }
}