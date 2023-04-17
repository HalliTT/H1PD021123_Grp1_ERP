using System.Drawing;
using Org.BouncyCastle.Bcpg;
using System.Security.Cryptography;
using Org.BouncyCastle.Bcpg.Sig;
using TECHCOOL.UI;

namespace App
{
    public class MenuScreen : Screen
    {
        public override string Title { get; set; }

        protected override void Draw()
        {
            //Screen.Display(new MenuScreen());
            Clear();
            Menu menu = new Menu();

            // Screens //

            // Sale
            //menu.Add(new SalesFullListScreen());

            // Company
            menu.Add(new CompanyList());

            // Product 
            // menu.Add(new ProductShortListScreen());

            // Customer
            // menu.Add(new CustomerShortListScreen());

            menu.Start(this);
        }
    }

    public class CompanyList : Screen
    {

        public override string Title { get; set; } = "List of Companies";

        public void CompanyFullList(ListPage<Company> Clist)
        {
            this.companyList = Clist;
        }

        protected ListPage<Company> _companyList = null!;

        public ListPage<Company> companyList
        {
            set { _companyList = value; }
            get { return _companyList; }
        }

        public ListPage<Company> listCompany = new ListPage<Company>();

        protected override void Draw()
        {
            Clear();
            Database database = new Database();
            companyList = new ListPage<Company>();
            foreach (var company in database.GetCompany())
            {
                listCompany.Add(company);
            }

            Clear();
            listCompany.AddColumn("Company", "name");
            listCompany.AddColumn("Country", "country");
            listCompany.AddColumn("Currency", "currency");
            listCompany.AddKey(ConsoleKey.F1, NewCompany);
            listCompany.AddKey(ConsoleKey.F2, EditCompany);
            listCompany.AddKey(ConsoleKey.F5, DeleteCompany);

            Company selected = listCompany.Select();
            Form<Company> editor = new Form<Company>();
            if (listCompany.Select() != null)
            {
                ShowCompany(selected);
            }
        }

        public void NewCompany(Company company)
        {
            Form<Company> editor = new Form<Company>();
            editor.TextBox("Company Name", "name");
            editor.TextBox("Road", "road");
            editor.TextBox("House Nr.", "houseNumber");
            editor.TextBox("Zip Code", "zipCode");
            editor.TextBox("City", "city");
            editor.TextBox("Country", "country");
            editor.SelectBox("Currency", "currency");
            editor.AddOption("Currency", "USD", "USD");
            editor.AddOption("Currency", "DKK", "DKK");
            editor.AddOption("Currency", "EUR", "EUR");
            editor.TextBox("CVR", "cvr");
            editor.TextBox("Email", "email");
            editor.Edit(company);

            Database database = new Database();
            database.InsertCompany(company);
            Clear();
            listCompany.Add(company);
        }


        public void ShowCompany(Company company)
        {
            Console.Clear();
            Console.WriteLine($"Company: {company.name}");
            Console.WriteLine($"Address Line 1: {company.road}");
            Console.WriteLine($"Address Line 2: {company.houseNumber}");
            Console.WriteLine($"Zipcode: {company.zipCode}");
            Console.WriteLine($"City: {company.city}");
            Console.WriteLine($"Country: {company.country}");
            Console.WriteLine($"Currency: {company.currency}");
            Console.WriteLine($"CVR: {company.cvr}");
            Console.WriteLine($"Email: {company.email}");
        }

        public void EditCompany(Company company)
        {
            Form<Company> editor = new Form<Company>();

            //Add a textbox
            Console.Clear();
            editor.TextBox("Company Name", "name");
            editor.TextBox("Road", "road");
            editor.TextBox("House Nr.", "houseNumber");
            editor.TextBox("Zip Code", "zipCode");
            editor.TextBox("City", "city");
            editor.TextBox("Country", "country");
            editor.SelectBox("Currency", "currency");
            editor.AddOption("Currency", "USD", "USD");
            editor.AddOption("Currency", "DKK", "DKK");
            editor.AddOption("Currency", "EUR", "EUR");
            editor.TextBox("CVR", "cvr");
            editor.TextBox("Email", "email");
            editor.Edit(company);

            // send inputs as new Query
            Database database = new Database();
            database.UpdateCompany(company);
            Clear();

        }

        public void DeleteCompany(Company company)
        {
            Form<Company> editor = new Form<Company>();
            Database database = new Database();
            database.DeleteCompany(company);
            listCompany.Remove(company);
        }
    }
    ////////////////SALE ORDERS////////////////////

    public class SalesList : Screen
    {

        public override string Title { get; set; } = "List of sale orders";

        public void SaleOrdersList(ListPage<Sales> SOlist)
        {
            this.orderList = SOlist;
        }

        protected ListPage<Sales> _orderList = null!;

        public ListPage<Sales> orderList
        {
            set { _orderList = value; }
            get { return _orderList; }
        }

        public ListPage<Sales> salesOrderList = new ListPage<Sales>();
        public ListPage<Customer> customerList = new ListPage<Customer>();

        protected override void Draw()
        {
            Clear();
            Database database = new Database();
            orderList = new ListPage<Sales>();
            foreach (Sales order in database.GetOrder())
            {
                salesOrderList.Add(order);
            }

            foreach (Person listcustomer in database.GetPerson())
            {
                
            }

            Clear();
            salesOrderList.AddColumn("Order Id", "orderId", 40);
            salesOrderList.AddColumn("Creation", "creationTimestamp", 25);
            salesOrderList.AddColumn("Done", "doneTimestamp", 25);
            salesOrderList.AddColumn("Customer Id", "customerId", 40);
            salesOrderList.AddColumn("Name", "name", 20);
            salesOrderList.AddKey(ConsoleKey.F1, NewSaleOrder);
            salesOrderList.AddKey(ConsoleKey.F2, EditOrder);
            salesOrderList.AddKey(ConsoleKey.F5, DeleteOrder);

            Sales selected = salesOrderList.Select();
            Form<Sales> editor = new Form<Sales>();
            if (salesOrderList.Select() != null)
            {
                ShowOrder(selected);
            }
        }

        public void NewSaleOrder(Person newCustomer)
        {
            // Fornavn, Efternavn, Vej, Husnummer, Postnummer, By, Telefonnummer, Email,
            Form<Person> editor = new Form<Person>();
            editor.TextBox("First Name", "firstName");
            editor.TextBox("Last Name", "lastName");
            editor.TextBox("Address line 1", "streetName");
            editor.TextBox("Address line 2", "houseNumber");
            editor.TextBox("Zip Code", "zipCode");
            editor.TextBox("City", "city");
            editor.TextBox("Country", "country");
            editor.TextBox("Phone number", "phoneNumber");
            editor.TextBox("Email", "email");
            editor.Edit(newCustomer);

            Database database = new Database();
            database.InsertOrder(newCustomer);
            Clear();
            listSales.Add(newCustomer);
        }


        public void ShowOrder(Sales order)
        {
            Console.Clear();
            Console.WriteLine($"FirstName: {order.customerId}");
            Console.WriteLine($"Last Name: {order.doneTimestamp}");
            Console.WriteLine($"Address Line 1 (road): {order.houseNumber}");
            Console.WriteLine($"Address Line 2 (number): {order.zipCode}");
            Console.WriteLine($"City: {company.city}");
            Console.WriteLine($"Country: {company.country}");
            Console.WriteLine($"Currency: {company.currency}");
            Console.WriteLine($"CVR: {company.cvr}");
            Console.WriteLine($"Email: {company.email}");
        }

        public void EditOrder(Sales order)
        {
            Form<Sales> editor = new Form<Sales>();

            //Add a textbox
            Console.Clear();
            editor.TextBox("First Name", "first");
            editor.TextBox("Last Name", "road");
            editor.TextBox("House Nr.", "houseNumber");
            editor.TextBox("Zip Code", "zipCode");
            editor.TextBox("City", "city");
            editor.TextBox("Country", "country");
            editor.SelectBox("Currency", "currency");
            editor.AddOption("Currency", "USD", "USD");
            editor.AddOption("Currency", "DKK", "DKK");
            editor.AddOption("Currency", "EUR", "EUR");
            editor.TextBox("CVR", "cvr");
            editor.TextBox("Email", "email");
            editor.Edit(order);

            // send inputs as new Query
            Database database = new Database();
            database.UpdateOrder(order);
            Clear();

        }

        public void DeleteOrder(Sales order)
        {
            Form<Company> editor = new Form<Company>();
            Database database = new Database();
            database.DeleteOrder(order);
            listSales.Remove(order);
        }
    }
    ////////////////////////////////////

    public class SalesFullListScreen : Screen
    {
        public SalesFullListScreen(ListPage<ExtendedSales> nnlist)
        {
            this.salesList = nnlist;
        }

        protected ListPage<ExtendedSales> _salesList;

        public ListPage<ExtendedSales> salesList
        {
            set { _salesList = value; }
            get { return _salesList; }
        }

        public override string Title { get; set; } = "List of sales";

        protected override void Draw()
        {
            Clear();
           

            Sales selected = salesList.Select();
            if (selected != null)
            {
                Clear();
                Screen.Display(new SalesSingleListScreen(selected));
            }
            else
            {
                Clear();
                Quit();
                return;
            }
        }
    }

    public class SalesSingleListScreen : Screen
    {
        public SalesSingleListScreen(Sales selected)
        {
            listSales.Add(selected);
        }

        public ListPage<Sales> listSales = new ListPage<Sales>();
        public override string Title { get; set; } = "salg";

        protected override void Draw()
        {
            Clear(this);
            listSales.AddColumn("Order Id", "orderId", 40);
            listSales.AddColumn("Creation", "creationTimestamp", 25);
            listSales.AddColumn("Done", "doneTimestamp", 25);
            listSales.AddColumn("Customer Id", "customerId", 40);
            listSales.AddColumn("Name", "name", 20);
            listSales.Draw();
        }
    }


    public class CustomerFullList : Screen
    {
        public override string Title { get; set; } = "Customer - Full List";

        public CustomerFullList(ListPage<Person> list)
        {
            this.customerList = list;
        }

        protected ListPage<Person> _customerList = null!;

        public ListPage<Person> customerList
        {
            set { _customerList = value; }
            get { return _customerList; }
        }

        protected override void Draw()
        {
            Clear(this);

            customerList.AddColumn("Id", "id");
            customerList.AddColumn("Name", "fullName");
            customerList.AddColumn("Phone", "phone");
            customerList.AddColumn("Email", "mail");

            customerList.Draw();
        }
    }

    public class CustomerShortList : Screen
    {
        public override string Title { get; set; } = "Customer - Full List";

        public CustomerShortList(ListPage<Person> list)
        {
            this.customers = list;
        }

        protected ListPage<Person> _customers = null!;

        public ListPage<Person> customers
        {
            set { _customers = value; }
            get { return _customers; }
        }

        protected override void Draw()
        {
            Clear(this);

            customers.AddColumn("Name", "fullName");
            customers.AddColumn("Address", "address");
            customers.AddColumn("Last purchase", "lastPurchase");

            customers.Draw();
        }
    }

}