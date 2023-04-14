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
            menu.Add(new CustomerList());

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
            salesList.AddColumn("Order Id", "orderId", 40);
            salesList.AddColumn("Creation", "creationTimestamp", 25);
            salesList.AddColumn("Done", "doneTimestamp", 25);
            salesList.AddColumn("Customer Id", "customerId", 40);
            salesList.AddColumn("Name", "name", 20);
            salesList.AddColumn("Price", "totalOrderPrice", 20);

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

    ////////////////////////////////////

    public class CustomerList : Screen
    {

        public override string Title { get; set; } = "List of Customer";

        public void CustomerFullList(ListPage<Person> list)
        {
            this.customerList = list;
        }

        protected ListPage<Person> _customerList = null!;

        public ListPage<Person> customerList
        {
            set { _customerList = value; }
            get { return _customerList; }
        }

        public ListPage<Person> listCostumer = new ListPage<Person>();


        protected override void Draw()
        {
            Clear();
            Database database = new Database();
            customerList = new ListPage<Person>();
            foreach (var person in database.GetPerson())
            {
                listCostumer.Add(person);
            }


            Clear();
            // listCostumer.AddColumn("Id", "id");
            listCostumer.AddColumn("Name", "fullName");
            listCostumer.AddColumn("Phone", "phone");
            listCostumer.AddColumn("Email", "mail");
            listCostumer.AddKey(ConsoleKey.F1, NewCostumer);
            listCostumer.AddKey(ConsoleKey.F2, EditCostumer);
            listCostumer.AddKey(ConsoleKey.F5, DeleteCostumer);

            Person selected = listCostumer.Select();
            Form<Company> editor = new Form<Company>();
            if (listCostumer.Select() != null)
            {
                ShowCostumer(selected);
            }
        }

        public void NewCostumer(Person customer)
        {
        }
        public void EditCostumer(Person customer)
        {
            Form<Person> editor = new Form<Person>();

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
            editor.Edit(customer);

            // send inputs as new Query
            Database database = new Database();
            database.UpdatePerson(customer);
            Clear();
        }

        public void DeleteCostumer(Person customer)
        {
            Form<Person> editor = new Form<Person>();
            Database database = new Database();
            database.DeletePerson(customer);
            customerList.Remove(customer);
        }

        public void ShowCostumer(Person costumer)
        {
            Console.Clear();
            Console.WriteLine($"Name: {costumer.fullName}");
            Console.WriteLine($"Address: {costumer.addString}");
            Console.WriteLine($"Last Bought: {costumer.lastPurchase}");
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

        public ListPage<Product> _list = new ListPage<Product> { };

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
