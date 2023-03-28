using H1PD021123_Grp1_ERP.Product;
using TECHCOOL.UI;

namespace App
{
    internal class Program
    {
        static Database db = new Database();
        public static void Main(string[] args)
        {
            CompanyFullListScreen companyFullListScreen = new CompanyFullListScreen();
            Screen.Display(companyFullListScreen);

            ///// ------ DB - TEST ------ /////
            
            List<Product> productList = new List<Product> { new Product("12", "test", 10.0, 10.0, "test", 10, Unit.meters) };

            var timestamp = DateTime.Now.ToString();

           // var order = new Sales(1234, timestamp, timestamp, "12", State.None, productList, 200);
            

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

            ProductScreen screen = new ProductScreen();
            Screen.Display(screen);

        }
    }
}