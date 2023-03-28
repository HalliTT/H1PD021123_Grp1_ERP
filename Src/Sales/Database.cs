using Microsoft.Data.SqlClient;
using Newtonsoft.Json;

namespace App
{
    public partial class Database
    {
        public List<Sales> GetOrder(uint orderNumber)
        {
            string queryString = $"SELECT * FROM dbo.Orders WHERE (OrderNumber = {orderNumber})";

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

                    order.Add(new Sales(Convert.ToUInt32(reader[0]),
                                     Convert.ToString(reader[1]),
                                     Convert.ToString(reader[2]),
                                     Convert.ToString(reader[3]),
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

                    orders.Add(new Sales(Convert.ToUInt32(reader[0]),
                                     Convert.ToString(reader[1]),
                                     Convert.ToString(reader[2]),
                                     Convert.ToString(reader[3]),
                                     state,
                                     JsonConvert.DeserializeObject<List<OrderLine>>(Convert.ToString(reader[5])),
                                     Convert.ToUInt32(reader[6])));
                }
            }

            return orders;
        }

        public void InsertOrder(Sales order)
        {
            string queryString = $"INSERT INTO dbo.Orders VALUES ('{order.orderNumber}', '{order.creationTimestamp}', '{order.doneTimestamp}', '{order.customerNumber}', '{order.state.ToString()}', '{JsonConvert.SerializeObject(order.orderLine)}', {order.totalOrderPrice})";

            SqlCommand command = new SqlCommand(queryString, this.connection);

            command.ExecuteNonQuery();
        }
         
        public void UpdateOrder(Sales order)
        {
            string queryString = $"UPDATE dbo.Orders SET (DoneTimestamp='{order.doneTimestamp}', CustomerNumber='{order.customerNumber}', State='{order.state.ToString()}', OrderList='{JsonConvert.SerializeObject(order.orderLine)}', TotalOrderPrice={order.totalOrderPrice}) WHERE OrderNumber={order.orderNumber}";

            SqlCommand command = new SqlCommand(queryString, this.connection);

            command.ExecuteNonQuery();
        }

        public void DeleteOrder(Sales order)
        {
            string queryString = $"DELETE FROM dbo.Orders WHERE OrderNumber={order.orderNumber}";

            SqlCommand command = new SqlCommand(queryString, this.connection);

            command.ExecuteNonQuery();
        }
    }
}