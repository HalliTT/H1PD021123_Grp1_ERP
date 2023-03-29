using TECHCOOL.UI;

namespace App
{
    internal class Program
    {
        static Database db = new Database();
        public static void Main(string[] args)
        {
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
    }
}