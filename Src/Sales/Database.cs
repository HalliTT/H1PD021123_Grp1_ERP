using Microsoft.Data.SqlClient;
using Newtonsoft.Json;

namespace App
{
    public partial class Database
    {
        public List<Sales> GetOrder(string orderId = "", string customerId = "")
        {
            string queryString = "";
            if (orderId.Length > 0 && customerId.Length <= 0)
            {
                queryString = $"SELECT * FROM dbo.Orders WHERE OrderId LIKE '{orderId}'";
            }
            else if (customerId.Length > 0 && orderId.Length <= 0)
            {
                queryString = $"SELECT * FROM dbo.Orders WHERE CustomerId LIKE '{customerId}'";

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

                    Guid id;
                    Guid.TryParse(Convert.ToString(reader[0]), out id);

                    // Customer id
                    Guid cId;
                    Guid.TryParse(Convert.ToString(reader[0]), out cId);

                    order.Add(new Sales(
                                    id,
                                    Convert.ToString(reader[1]),
                                    Convert.ToString(reader[2]),
                                    cId,
                                    state,
                                    JsonConvert.DeserializeObject<List<OrderLine>>(Convert.ToString(reader[5])),
                                    Convert.ToUInt32(reader[6])));
                }
            }

            return order;
        }

        public List<Sales> GetOrders()
        {
            string queryString = "SELECT * FROM dbo.Orders";

            SqlCommand command = new SqlCommand(queryString, this.connection);

            command.ExecuteNonQuery();

            List<Sales> orders = new List<Sales> { };

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    App.State state;
                    Enum.TryParse<App.State>(Convert.ToString(reader[4]), out state);

                    Guid id;
                    Guid.TryParse(Convert.ToString(reader[0]), out id);

                    Guid customerId;
                    Guid.TryParse(Convert.ToString(reader[0]), out customerId);

                    orders.Add(new Sales(
                                    id,
                                    Convert.ToString(reader[1]),
                                    Convert.ToString(reader[2]),
                                    customerId,
                                    state,
                                    JsonConvert.DeserializeObject<List<OrderLine>>(Convert.ToString(reader[5])),
                                    Convert.ToUInt32(reader[6])));
                }
            }

            return orders;
        }

        public void InsertOrder(Sales order)
        {
            string queryString = $"INSERT INTO dbo.Orders VALUES ('{order.orderId.ToString()}', '{order.creationTimestamp}', '{order.doneTimestamp}', '{order.customerId.ToString()}', '{order.state.ToString()}', '{JsonConvert.SerializeObject(order.orderLine)}', {order.totalOrderPrice})";

            SqlCommand command = new SqlCommand(queryString, this.connection);

            command.ExecuteNonQuery();
        }

        public void UpdateOrder(Sales order)
        {
            string queryString = $"UPDATE dbo.Orders SET (DoneTimestamp='{order.doneTimestamp}', CustomerId='{order.customerId.ToString()}', State='{order.state.ToString()}', OrderList='{JsonConvert.SerializeObject(order.orderLine)}', TotalOrderPrice={order.totalOrderPrice}) WHERE OrderId={order.orderId.ToString()}";

            SqlCommand command = new SqlCommand(queryString, this.connection);

            command.ExecuteNonQuery();
        }

        public void DeleteOrder(Sales order)
        {
            string queryString = $"DELETE FROM dbo.Orders WHERE OrderNumber={order.orderId}";

            SqlCommand command = new SqlCommand(queryString, this.connection);

            command.ExecuteNonQuery();
        }
    }
}