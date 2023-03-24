using Microsoft.Data.SqlClient;

namespace App
{
    public partial class Database
    {
        public List<Sales> GetOrder(uint orderNumber)
        {
            string queryString = $"SELECT * FROM dbo.Orders WHERE (OrderNumber = {orderNumber})";

            SqlCommand command = new SqlCommand(queryString, connection);
            
            command.ExecuteNonQuery();

            List<Sales> order = new List<Sales> {};

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    // Trying to parse string to enum<State>
                    App.State state;
                    Enum.TryParse<App.State>(Convert.ToString(reader[4]), out state);

                    order.Append(new Sales(Convert.ToUInt32(reader[0]), 
                                     Convert.ToString(reader[1]), 
                                     Convert.ToString(reader[2]), 
                                     Convert.ToString(reader[3]), 
                                     state, 
                                     new List<Product> { new Product("12", "test", 1, 10.0, 10.0, "test", 10, Unit.meter) }, // TODO - this is dummy data and shoudl replaced by a function which can convert a string to List<Product>
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

            List<Sales> orders = new List<Sales> {};

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    // TODO - idk what is needed to be done with read.
                }
            }

            return orders;
        }

        public void InsertOrder(Sales order)
        {
            string queryString = $"INSERT INTO dbo.Orders VALUES ('{order.orderNumber}', '{order.creationTimestamp}', '{order.doneTimestamp}', '{order.customerNumber}', '{order.state.ToString()}', '{order.orderList.ToString()}', {order.totalOrderPrice})";

            SqlCommand command = new SqlCommand(queryString, this.connection);
            
            command.ExecuteNonQuery();
        }

        public void UpdateOrder(Sales order)
        {
            string queryString = $"UPDATE dbo.Orders SET (DoneTimestamp='{order.doneTimestamp}', CustomerNumber='{order.customerNumber}', State='{order.state.ToString()}', OrderList='{order.orderList.ToString()}', TotalOrderPrice={order.totalOrderPrice}) WHERE OrderNumber={order.orderNumber}";

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