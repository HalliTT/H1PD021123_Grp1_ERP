using System.Data;
using TECHCOOL.UI;

namespace App
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var db = new Database();
            db.TestConnection();
            // Company
            var companyList = db.GetCompany();
            var companyListPage = new ListPage<Company> {};

            if (companyList.Capacity < 1)
                companyList.Add(new Company("Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", Currency.DKK, "Unknown", "Unknown"));

            companyListPage.Add(companyList);

            var company = new SetupCompanyInterface("Company", companyListPage);

            var companyScreen = company.Show();

            // Person
            var personList = db.GetPerson();
            var personListPage = new ListPage<Person> {};

            personListPage.Add(personList); 

            var person = new SetupPersonInterface("Person", personListPage);

            var personScreen = person.Show();

            // Product
            var productList = db.GetProduct();
            var productListPage = new ListPage<Product> {};

            productListPage.Add(productList);

            var product = new SetupProductInterface("Product", productListPage);

            var productScreen = product.Show();

            // Sales
            var salesList = db.GetOrder();
            var salesListPage = new ListPage<Sales> {};
            
            salesListPage.Add(salesList);

            var sales = new SetupSalesInterface("Sales", salesListPage);

            var salesScreen = sales.Show();

            // Menu
            Screen[] screens = {companyScreen, personScreen, productScreen, salesScreen};
            
            var menu = new MenuInterface(screens);
            Screen.Display(menu);
        }
    }
}
