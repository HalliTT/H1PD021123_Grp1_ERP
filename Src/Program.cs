using System.CodeDom;
using TECHCOOL.UI;

namespace App
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Console.WriteLine("choose: 1. short list companies 2. full list companies");
            // int choice = Int32.Parse(Console.ReadLine());
            //     switch (choice)
            //     {
            //         case 1:
            //             CompanyShortListScreen companyShortListScreen = new CompanyShortListScreen();
            //             Screen.Display(companyShortListScreen);   
            //             break;
            //         case 2:
            //             CompanyFullListScreen companyFullListScreen = new CompanyFullListScreen();
            //             Screen.Display(companyFullListScreen);
            //             break;
            //         default:
            //             Console.WriteLine("wrong input");
            //             break;
            //     }
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

            //var db = new Database();

            // var customerid = Guid.NewGuid();
            // var orderId = Guid.NewGuid();

            // var productList = new List<OrderLine> { new OrderLine(orderId, new Product(Guid.NewGuid(), "test", 10.0, 10.0, "test", 10, Unit.meters), 1, orderId, Guid.NewGuid()) };

            // var timestamp = DateTime.Now.ToString();

            // var order = new Sales(orderId, timestamp, timestamp, customerid, State.None, productList, 200);

            // db.InsertOrder(order);

            // var person = new Person(customerid, "iAmFirstName", "iAmLastName", "222", "as@as.dk", new Adress("dk", "2990", "Aalbo", "newcoa", "22"), Role.Customer, db.GetTimeStamp(customerid));

            // db.InsertPerson(person);

            //Sales and person
            // var orders = db.GetOrders();

            // var extendedSalesList = new ListPage<ExtendedSales> { };
            // foreach (var _order in orders)
            // {
            //     var _person = db.GetPerson(_order.customerId);
            //     var extendedOrder = new ExtendedSales(_order.orderId, _order.creationTimestamp, _order.doneTimestamp, _order.customerId, _order.state, _order.orderLine, _person[0].firstName + " " + _person[0].lastName, _order.totalOrderPrice);

            //     extendedSalesList.Add(extendedOrder);
            // }
            // var display = new SalesFullListScreen(extendedSalesList);
            // Screen.Display(display);

            // db.DeleteOrder(order);
            // db.DeleteOrder(orderTwo);

            //another impl
            // var products = new Product.Product("", "", 0, 0, 0, "", 0, Product.Unit.meter);
            // products.PrintProducts();

            var list = new ListPage<Product> {};
    
            var p1 = new Product(Guid.NewGuid(), "p1", 90, 100, "test", 2, Unit.meters);
            list.Add(p1);

            var p2 = new Product(Guid.NewGuid(), "p2", 100, 200, "test", 25, Unit.pieces);
            list.Add(p2);

            var screen = new ProductFullList(list);
            Screen.Display(screen);

        }
    }
}

