using Org.BouncyCastle.Bcpg;
using System.Security.Cryptography;
using TECHCOOL.UI;

namespace App
{
    public class MenuScreen : Screen
    {
        public override string Title { get; set; }

        protected override void Draw()
        {
            //Screen.Display(new MenuScreen());
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
            foreach (var company in database.GetCompanies())
            {
                listCompany.Add(company);
            }
            listCompany.AddColumn("Company", "name");
            listCompany.AddColumn("Country", "country");
            listCompany.AddColumn("Currency", "currency");
            listCompany.AddKey(ConsoleKey.F1, ShowCompany);
            listCompany.AddKey(ConsoleKey.F2, EditCompany);

            Company selected = listCompany.Select();
            Form<Company> editor = new Form<Company>();

            // TODO: need to add catch for F1 input using AddKey from Techcool
            if (selected != null)
            {
                // clear techcool draws
                Clear(this);
                EditCompany(selected);
            }
            else
            {
                // Quit();
                return;
            }
        }

        public void ShowCompany(Company company)
        {
            Clear();
            listCompany.AddColumn("Company", "name");
            listCompany.AddColumn("Address Line 1", "road");
            listCompany.AddColumn("Address Line 2", "houseNumber");
            listCompany.AddColumn("Zipcode", "zipCode");
            listCompany.AddColumn("City", "city");
            listCompany.AddColumn("Country", "country");
            listCompany.AddColumn("Currency", "currency");
            listCompany.AddColumn("CVR", "cvr");
            listCompany.AddColumn("Email", "email");
        }

        public void EditCompany(Company company)
        {
            Company selected = listCompany.Select();
            Form<Company> editor = new Form<Company>();

            // Clear console for clean draw
            Clear(this);

            //Add a textbox
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
            editor.Edit(selected);

            Console.TreatControlCAsInput = true;
            ConsoleKeyInfo conKey = Console.ReadKey();
            if (conKey.Equals(ConsoleKey.Escape))
            {
                // send inputs as new Query
                Database database = new Database();
                database.UpdateCompany(selected);
            }
        }
    }

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
            Clear(this);
            salesList.AddColumn("Order Id", "orderId", 40);
            salesList.AddColumn("Creation", "creationTimestamp", 25);
            salesList.AddColumn("Done", "doneTimestamp", 25);
            salesList.AddColumn("Customer Id", "customerId", 40);
            salesList.AddColumn("Name", "name", 20);
            salesList.AddColumn("Price", "totalOrderPrice", 20);

            Sales selected = salesList.Select();
            if (selected != null)
            {
                Screen.Display(new SalesSingleListScreen(selected));
            }
            else
            {
                Quit();
                return;
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

    public class ProductShortList : Screen
    {
        public override string Title { get; set; } = "Customer - Full List";

        public ProductShortList(ListPage<Product> list)
        {
            this.list = list;
        }

        protected ListPage<Product> _list = null!;

        public ListPage<Product> list
        {
            set { _list = value; }
            get { return _list; }
        }

        protected override void Draw()
        {
            Clear(this);

            list.AddColumn("Id", "Id");
            list.AddColumn("Name", "name");
            list.AddColumn("Amount", "amountInStock");
            list.AddColumn("Purchase price", "purchasePrice");
            list.AddColumn("Sales price", "salesPrice");
            list.AddColumn("Profit", "profit");

            var selected = list.Select();

            if (selected != null)
            {
                Screen.Display(new ProductFull(selected));
            }
            else
            {
                Quit();
                return;
            }
        }
    }

    public class ProductFull : Screen
    {
        public override string Title { get; set; } = "Customer - Full List";

        public ProductFull(Product product)
        {
            this.list.Add(product);
        }

        public ListPage<Product> _list = new ListPage<Product> {};

        public ListPage<Product> list
        {
            set { _list = value; }
            get { return _list; }
        }

        protected override void Draw()
        {
            Clear(this);

            list.AddColumn("Id", "Id");
            list.AddColumn("Name", "name");
            list.AddColumn("Description", "description");
            list.AddColumn("Sales price", "salesPrice");
            list.AddColumn("Purchase price", "purchasePrice");
            list.AddColumn("Location", "location");
            list.AddColumn("Amount", "amountInStock");
            list.AddColumn("Unit", "unit");
            list.AddColumn("Profit", "percentageProfit");
            list.AddColumn("Profit", "profit");

            list.Draw();
        }
    }
}