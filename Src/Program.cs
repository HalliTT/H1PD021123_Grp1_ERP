using TECHCOOL.UI;

namespace App
{
    internal class Program
    {
        static Database db = new Database();
        static void Main(string[] args)
        {

            ///// ------ Haraldur Test ------ /////
            // var shortScreen = new CompanyShortListScreen();
            // Screen.Display(shortScreen);
            // var fullScreen = new CompanyFullListScreen();
            // Screen.Display(fullScreen);

            ///// ------ DB - TEST ------ /////
            
            var product = new Product("12", "test", 1, 10.0, "test", 10, Unit.meters);

            var orderline = new List<OrderLine> { new OrderLine("123", product, 1, "2", "3") };

            var timestamp = DateTime.Now.ToString();

            var order = new Sales(1234, timestamp, timestamp, "12", State.None, orderline, 200);

            var db = new Database();

            db.InsertOrder(order);

            Console.WriteLine("Press enter to get order from db");
            Console.ReadLine();

            var orders = db.GetOrder(1234);

            foreach (var i in orders)
            {
                Console.WriteLine(i.customerNumber);
            }

            db.DeleteOrder(order);
            
            //another impl
            // var products = new Product.Product("", "", 0, 0, 0, "", 0, Product.Unit.meter);
            // products.PrintProducts();

            ///// ------ Sebastian Test ------ /////
            // MyFirstScreen firstScreen = new MyFirstScreen();
            // TodoListScreen todo = new TodoListScreen();
            // CustomerListScreen customerList = new CustomerListScreen();
            // Screen.Display(customerList);
        }
    }
}