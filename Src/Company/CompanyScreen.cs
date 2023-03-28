using System;
using System.ComponentModel;
using TECHCOOL;
using TECHCOOL.UI;

namespace App
{

    public class CompanyFullListScreen : Screen
    {
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
        public override string Title { get; set; } = "List of Companies";
        
        protected override void Draw()
        {
            Clear(this);
            ListPage<Company> listCompany = new ListPage<Company>();
            listCompany.Add(new Company("700", "Mars", "Hovedvejen", "88", "9200", "Nørresundby", "Denmark", "Dkk", "29 22 00 10", "Mars@Mars.dk"));
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
            if (selected != null)
            {
                Screen.Display(new CompanyShortListScreen(selected));
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
        public override string Title { get; set; } = "List of Companies";

        public CompanyShortListScreen(Company selected)
        {
            listCompany.Add(selected);
        }
        public ListPage<Company> listCompany = new ListPage<Company>();

        protected override void Draw()
        {
            Clear(this);
            listCompany.Add(new Company("200", "Venus", "Landevejen", "2", "9000", "Aalborg", "Denmark", "Dkk", "29 54 90 22", "Venus@venus.dk"));
            listCompany.Add(new Company("700", "Mars", "Hovedvejen", "88", "9200", "Nørresundby", "Denmark", "Dkk", "29 22 00 10", "Mars@Mars.dk"));
            listCompany.AddColumn("Company", "companyName");
            listCompany.AddColumn("Country", "companyCountry");
            listCompany.AddColumn("Currency", "companyCurrency");
            listCompany.Draw();
        }
    }
    public class EditCompany : Screen
    {
        public override string Title { get; set; } = "Edit Company"; 
        protected override void Draw()
        {
            Clear(this);
            Company listCompany = new Company(
                "200", 
                "Venus", 
                "Landevejen", 
                "2", 
                "9000", 
                "Aalborg", 
                "Denmark", 
                "Dkk", 
                "29 54 90 22", 
                "Venus@venus.dk"
                );
            //Create instance
            Form<Company> editor = new Form<Company>();

            //Add a textbox
            editor.TextBox("Company Name", "companyName");
            editor.TextBox("Road", "companyRoad");
            editor.TextBox("House Nr.", "companyHouseNumber");
            editor.TextBox("Zip Code", "companyZipCode");
            editor.TextBox("City", "companyCity");
            editor.TextBox("Country", "Priority");
            editor.SelectBox("Currency", "Currency");
            editor.AddOption("Currency", "USD", "USD");
            editor.AddOption("Currency", "DKK", "DKK");
            editor.AddOption("Currency", "EUR", "EUR");
            editor.Edit(listCompany);

            Clear(this);
            Console.WriteLine($"Company {listCompany.companyName} is {listCompany.companyCurrency}");

            //Draw the editor
            editor.Edit(listCompany);
        }
    }
}