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
            
            List<Product> productList = new List<Product> { new Product("12", "test", 1, 10.0, 10.0, "test", 10, Unit.meter) };

            var timestamp = DateTime.Now.ToString();

            var order = new Sales(1234, timestamp, timestamp, "12", State.None, productList, 200);
            
            var db = new Database();

            db.InsertOrder(order);

            Console.WriteLine("Press enter to delete order from db");
            Console.ReadLine();

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