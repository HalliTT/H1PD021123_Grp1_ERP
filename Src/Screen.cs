using TECHCOOL.UI;

namespace App
{
    public class MenuScreen : Screen
    {
        public override string Title { get; set; }

        protected override void Draw()
        {
            Screen.Display(new MenuScreen());
            Menu menu = new Menu();

            // Screens //

            // Sale
            // menu.Add(new SaleShortListScreen());

            // Company
            menu.Add(new CompanyShortListScreen());

            // Product 
            // menu.Add(new ProductShortListScreen());

            // Customer
            // menu.Add(new CustomerShortListScreen());

            menu.Start(this);
        }

    }

    public class CompanyFullListScreen : Screen
    {
        public override string Title { get; set; } = "Full List of Companies";

        public void CompanyFullList(ListPage<Company> Clist)
        {
            this.companyList = Clist;
        }

        protected ListPage<Company> _companyList;

        public ListPage<Company> companyList
        {
            set { _companyList = value; }
            get { return _companyList; }
        }

        public ListPage<Company> listCompany = new ListPage<Company>();

        protected override void Draw(Guid id)
        {
            Clear();
            listCompany.Add(new Company(id, "Venus", "Landevejen", "2", "9000", "Aalborg", "Denmark",
                Currency.DKK, "29 54 90 22", "Venus@venus.dk"));
            listCompany.Add(new Company(id, "Mars", "Hovedvejen", "88", "9200", "Nørresundby", "Denmark",
                Currency.DKK, "29 22 00 10", "Mars@Mars.dk"));
            listCompany.AddColumn($"id", "companyId");
            listCompany.AddColumn("Company", "companyName");
            listCompany.AddColumn("Road", "companyRoad");
            listCompany.AddColumn("House Number", "companyHouseNumber");
            listCompany.AddColumn("Zip Code", "companyZipCode");
            listCompany.AddColumn("City", "companyCity");
            listCompany.AddColumn("Country", "companyCountry");
            listCompany.AddColumn("Currency", "companyCurrency");
            listCompany.AddColumn("CVR", "companyCvr");
            listCompany.AddColumn("Email", "companyEmail");

            Company selected = listCompany.Select();
            Form<Company> editor = new Form<Company>();


            if (selected != null)
            {
                // TEST
                Clear(this);
                //Add a textbox
                editor.TextBox("Company Name", "companyName");
                editor.TextBox("Road", "companyRoad");
                editor.TextBox("House Nr.", "companyHouseNumber");
                editor.TextBox("Zip Code", "companyZipCode");
                editor.TextBox("City", "companyCity");
                editor.TextBox("Country", "companyCountry");
                editor.SelectBox("Currency", "companyCurrency");
                editor.AddOption("Currency", "USD", "USD");
                editor.AddOption("Currency", "DKK", "DKK");
                editor.AddOption("Currency", "EUR", "EUR");
                editor.TextBox("CVR", "companyCvr");
                editor.TextBox("Email", "companyEmail");
                editor.Edit(selected);
                //Console.WriteLine($"Company {selected.companyName} is {selected.companyCurrency}");
                var input = Console.ReadKey();

                //Draw the editor
                editor.Edit(selected);
                //
                Screen.Display(new CompanyFullListScreen());
            }
            else
            {
                Quit();
                return;
            }
        }
    }

    public class CompanyShortListScreen : Screen
    {

        public override string Title { get; set; } = "Short List of Companies";

        public void CompanyShortList(ListPage<Company> SClist)
        {
            this.companyList = SClist;
        }

        protected ListPage<Company> _companyList;

        public ListPage<Company> companyList
        {
            set { _companyList = value; }
            get { return _companyList; }
        }

        public ListPage<Company> listCompany = new ListPage<Company>();
        Form<Company> editor = new Form<Company>();

        public void NewCompany(Company company)
        {
            Company selected = listCompany.Select();
            // TEST
            Clear(this);
            //Add a textbox
            var editCompanyName = editor.TextBox("Company Name", "companyName");
            var editCompanyRoad = editor.TextBox("Road", "companyRoad");
            editor.TextBox("House Nr.", "companyHouseNumber");
            editor.TextBox("Zip Code", "companyZipCode");
            editor.TextBox("City", "companyCity");
            editor.TextBox("Country", "companyCountry");
            editor.Edit(selected);
            // Console.WriteLine($"Company {selected.companyName} is {selected.companyCurrency}");
        }

        protected override void Draw(Guid id)
        {
            Company selected = listCompany.Select();

            Clear();
            listCompany.Add(new Company(id, "Venus", "Landevejen", "2", "9000", "Aalborg", "Denmark",
                Currency.DKK, "29 54 90 22", "Venus@venus.dk"));
            listCompany.Add(new Company(id, "Mars", "Hovedvejen", "88", "9200", "Nørresundby", "Denmark",
                Currency.DKK, "29 22 00 10", "Mars@Mars.dk"));
            listCompany.AddColumn("Company", "companyName");
            listCompany.AddColumn("Road", "companyRoad");
            listCompany.AddColumn("House Number", "companyHouseNumber");
            listCompany.AddColumn("Zip Code", "companyZipCode");
            listCompany.AddColumn("City", "companyCity");

            // input
            listCompany.AddKey(ConsoleKey.F1, NewCompany);
            // listCompany.Draw();

            if (selected != null)
            {
                //Draw the editor
                editor.Edit(selected);

                //
                Screen.Display(new CompanyShortListScreen());
            }
            else
            {
                Quit();
                return;
            }
        }


        // TEST setup - below code safe to delete when function for screen is implemented fully //
        // public class EditCompany : Screen
        // {
        //     public override string Title { get; set; } = "Edit Company"; 
        // protected override void Draw()
        // {
        //     Clear(this);
        //     Company listCompany = new Company(
        //         "200", 
        //         "Venus", 
        //         "Landevejen", 
        //         "2", 
        //         "9000", 
        //         "Aalborg", 
        //         "Denmark", 
        //         CompanyCurrency.DKK, 
        //         "29 54 90 22", 
        //         "Venus@venus.dk"
        //         );
        //     //Create instance
        //     Form<Company> editor = new Form<Company>();
        //
        //     //Add a textbox
        //     Clear(this);
        //     editor.TextBox("Company Name", "companyName");
        //     editor.TextBox("Road", "companyRoad");
        //     editor.TextBox("House Nr.", "companyHouseNumber");
        //     editor.TextBox("Zip Code", "companyZipCode");
        //     editor.TextBox("City", "companyCity");
        //     editor.TextBox("Country", "Priority");
        //     editor.SelectBox("Currency", "Currency");
        //     editor.AddOption("Currency", "USD", "USD");
        //     editor.AddOption("Currency", "DKK", "DKK");
        //     editor.AddOption("Currency", "EUR", "EUR");
        //     editor.Edit(listCompany);
        //
        //     Clear(this);
        //     Console.WriteLine($"Company {listCompany.companyName} is {listCompany.companyCurrency}");
        //
        //     //Draw the editor
        //     editor.Edit(listCompany);
        // }
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
    
    public class ProductFullList : Screen
    {
        public override string Title { get; set; } = "Customer - Full List";

        public ProductFullList(ListPage<Product> list)
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

            list.AddColumn("Id", "productId");
            list.AddColumn("Name", "name");
            list.AddColumn("Amount", "amountInStock");
            list.AddColumn("Purchase price", "purchasePrice");
            list.AddColumn("Sales price", "salesPrice");
            list.AddColumn("Profit", "profit");

            var selected = list.Select();

            if (selected != null)
            {
                Clear(this);
                Console.WriteLine("TODO: implement P3");
            }
            else
            {
                Quit();
                return;
            }
        }
    }
}


