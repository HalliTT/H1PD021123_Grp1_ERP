using H1PD021123_Grp1_ERP.Customer;
using System;
using TECHCOOL;
using TECHCOOL.UI;
using H1PD021123_Grp1_ERP.Screens;


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

            ///// ------ DB ------ /////
            var db = new Database();
            db.GetProducts();

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