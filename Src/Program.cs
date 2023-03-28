using H1PD021123_Grp1_ERP.Product;
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
            
           
            var timestamp = DateTime.Now.ToString();
           var order = new Sales(1234, timestamp, timestamp, "12", State.None, 200);
            
            var db = new Database();

            //db.InsertOrder(order);

            Console.WriteLine("Press enter to delete order from db");
            Console.ReadLine();

            db.DeleteOrder(order);
            

            //another impl
            // var products = new Product.Product("", "", 0, 0, 0, "", 0, Product.Unit.meter);
            // products.PrintProducts();

            ///// ------ Sebastian Test ------ /////
           
            //ProductScreen screen = new ProductScreen();
            //Screen.Display(screen); 
           
        }
    }
}