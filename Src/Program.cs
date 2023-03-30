using System.CodeDom;
using TECHCOOL.UI;

namespace App
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("choose: 1. short list companies 2. full list companies");
            int choice = Int32.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        CompanyShortListScreen companyShortListScreen = new CompanyShortListScreen();
                        Screen.Display(companyShortListScreen);   
                        break;
                    case 2:
                        CompanyFullListScreen companyFullListScreen = new CompanyFullListScreen();
                        Screen.Display(companyFullListScreen);
                        break;
                    default:
                        Console.WriteLine("wrong input");
                        break;
                }
        ///// ------ DB - TEST ------ /////

            //List<Product> productList = new List<Product> { new Product("12", "test", 10.0, 10.0, "test", 10, Unit.meters) };

            //var timestamp = DateTime.Now.ToString();

            // var order = new Sales(1234, timestamp, timestamp, "12", State.None, productList, 200);
            

            ///// ------ Haraldur SalesScreen ------ /////
            // var db = new Database();
            // var orders = db.GetOrders();
            // var listSales = new ListPage<Sales>();
            // foreach (var orderI in orders)
            // {
            //     listSales.Add(orderI);
            // }
            // var fullListScreen = new SalesFullListScreen(listSales);
            // Screen.Display(fullListScreen);
            // CompanyFullListScreen companyFullListScreen = new CompanyFullListScreen();
            // Screen.Display(companyFullListScreen);

            ///// ------ DB - TEST ------ /////

            var customerid = Guid.NewGuid();
            var orderId = Guid.NewGuid();

            var productList = new List<OrderLine> { new OrderLine(orderId, new Product(Guid.NewGuid(), "test", 10.0, 10.0, "test", 10, Unit.meters), 1, orderId, Guid.NewGuid()) };

            var timestamp = DateTime.Now.ToString();

            var order = new Sales(orderId, timestamp, timestamp, customerid, State.None, productList, 200);


            ///// ------ Haraldur SalesScreen ------ /////
            var db = new Database();

            db.InsertOrder(order);

            var person = new Person(Guid.NewGuid(), "iAmFirstName", "iAmLastName", "222", "as@as.dk", new Adress("dk", "2990", "Aalbo", "newcoa", "22"), Role.Customer, db.GetTimeStamp(customerid));

            db.InsertPerson(person);

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

        static Database db = new Database();
    }
}

