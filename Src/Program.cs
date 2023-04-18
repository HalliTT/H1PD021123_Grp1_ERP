using TECHCOOL.UI;

namespace App
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Company
            var companyList = new ListPage<Company> {};

            var companyObj = new Company("Virk", "vej", "2", "9000", "Aalborg", "DK", Currency.DKK, "123", "test@test.dk");
            companyList.Add(companyObj);

            var company = new SetupCompanyInterface("Company", companyList);

            var companyScreen = company.Show();

            // Person
            var personList = new ListPage<Person> {};

            var personObj = new Person("for", "efter", "1234567", "test@test.dk", new Address("DK", "9000", "DK", "Vej", "200"), Role.Customer);
            personList.Add(personObj);

            var person = new SetupPersonInterface("Person", personList);

            var personScreen = person.Show();

            // Product
            var productList = new ListPage<Product> {};

            var productObj = new Product("Produkt", "desc", 200, 10020, "DK", 200, Unit.hours);
            productList.Add(productObj);

            var product = new SetupProductInterface("Product", productList);

            var productScreen = product.Show();

            // Sales
            var salesList = new ListPage<Sales> { };

            var salesObj = new Sales(DateTime.Now.ToString(), DateTime.Now.ToString(), 2, State.Created, 2000);
            salesList.Add(salesObj);

            var sales = new SetupSalesInterface("Sales", salesList);

            var salesScreen = sales.Show();

            // Menu
            Screen[] screens = {companyScreen, personScreen, productScreen, salesScreen};
            
            var menu = new MenuInterface(screens);
            Screen.Display(menu);
        }
    }
}