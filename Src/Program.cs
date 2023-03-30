using TECHCOOL.UI;

namespace App
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // CompanyFullListScreen companyFullListScreen = new CompanyFullListScreen();
            // Screen.Display(companyFullListScreen);

            ///// ------ DB - TEST ------ /////

            var db = new Database();

            // var customerid = Guid.NewGuid();
            // var orderId = Guid.NewGuid();

            // var productList = new List<OrderLine> { new OrderLine(orderId, new Product(Guid.NewGuid(), "test", 10.0, 10.0, "test", 10, Unit.meters), 1, orderId, Guid.NewGuid()) };

            // var timestamp = DateTime.Now.ToString();

            // var order = new Sales(orderId, timestamp, timestamp, customerid, State.None, productList, 200);

            // db.InsertOrder(order);

            // var person = new Person(customerid, "iAmFirstName", "iAmLastName", "222", "as@as.dk", new Adress("dk", "2990", "Aalbo", "newcoa", "22"), Role.Customer, db.GetTimeStamp(customerid));

            // db.InsertPerson(person);

            //Sales and person
            var orders = db.GetOrders();

            var extendedSalesList = new ListPage<ExtendedSales> { };
            foreach (var _order in orders)
            {
                var _person = db.GetPerson(_order.customerId);
                var extendedOrder = new ExtendedSales(_order.orderId, _order.creationTimestamp, _order.doneTimestamp, _order.customerId, _order.state, _order.orderLine, _person[0].firstName + " " + _person[0].lastName, _order.totalOrderPrice);

                extendedSalesList.Add(extendedOrder);
            }
            var dd = new SalesFullListScreen(extendedSalesList);
            Screen.Display(dd);

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