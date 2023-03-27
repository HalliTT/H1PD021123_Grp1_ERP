using TECHCOOL.UI;

namespace App
{
    internal class Program
    {
        static Database db = new Database();
        static void Main(string[] args)
        {

            ///// ------ Haraldur SalesScreen ------ /////
            var db = new Database();
            var orders = db.GetOrders();
            var listSales = new ListPage<Sales>();
            foreach (var orderI in orders)
            {
                listSales.Add(orderI);
            }
            var fullListScreen = new SalesFullListScreen(listSales);
            Screen.Display(fullListScreen);

            // db.DeleteOrder(order);
            // db.DeleteOrder(orderTwo);

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