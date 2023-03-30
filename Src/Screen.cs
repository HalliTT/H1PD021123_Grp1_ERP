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

        protected override void Draw()
        {
            Clear();
            listCompany.Add(new Company("200", "Venus", "Landevejen", "2", "9000", "Aalborg", "Denmark",
                CompanyCurrency.DKK, "29 54 90 22", "Venus@venus.dk"));
            listCompany.Add(new Company("700", "Mars", "Hovedvejen", "88", "9200", "Nørresundby", "Denmark",
                CompanyCurrency.DKK, "29 22 00 10", "Mars@Mars.dk"));
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

        protected override void Draw()
        {
            Company selected = listCompany.Select();

            Clear();
            listCompany.Add(new Company("200", "Venus", "Landevejen", "2", "9000", "Aalborg", "Denmark",
                CompanyCurrency.DKK, "29 54 90 22", "Venus@venus.dk"));
            listCompany.Add(new Company("700", "Mars", "Hovedvejen", "88", "9200", "Nørresundby", "Denmark",
                CompanyCurrency.DKK, "29 22 00 10", "Mars@Mars.dk"));
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
}