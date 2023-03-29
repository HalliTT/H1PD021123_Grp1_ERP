using System;
using System.CodeDom;
using System.ComponentModel;
using System.Data.Entity.Core.EntityClient;
using System.Net.Mime;
using Org.BouncyCastle.Bcpg;
using TECHCOOL;
using TECHCOOL.UI;

namespace App
{

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
            listCompany.Add(new Company("200", "Venus", "Landevejen", "2", "9000", "Aalborg", "Denmark",CompanyCurrency.DKK, "29 54 90 22", "Venus@venus.dk"));
            listCompany.Add(new Company("700", "Mars", "Hovedvejen", "88", "9200", "Nørresundby", "Denmark", CompanyCurrency.DKK, "29 22 00 10", "Mars@Mars.dk"));
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
                
                // test - returning from menu
                if (input.Key == ConsoleKey.Backspace)
                {
                    return;
                }

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

    public void NewCompany(Company company)
    {
        
    }

    protected override void Draw()
    {
        Clear();
        listCompany.Add(new Company("200", "Venus", "Landevejen", "2", "9000", "Aalborg", "Denmark",CompanyCurrency.DKK, "29 54 90 22", "Venus@venus.dk"));
        listCompany.Add(new Company("700", "Mars", "Hovedvejen", "88", "9200", "Nørresundby", "Denmark", CompanyCurrency.DKK, "29 22 00 10", "Mars@Mars.dk"));
        listCompany.AddColumn("Company", "companyName");
        listCompany.AddColumn("Road", "companyRoad");
        listCompany.AddColumn("House Number", "companyHouseNumber");
        listCompany.AddColumn("Zip Code", "companyZipCode");
        listCompany.AddColumn("City", "companyCity");
        listCompany.AddKey(ConsoleKey.F1, NewCompany);
        // listCompany.Draw();
        Company selected = listCompany.Select();
        var input = Console.ReadKey();
        Form<Company> editor = new Form<Company>();
        if (selected != null)
        {
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
            Console.WriteLine("F1 = Create new company");
            
            // test - returning from menu
            if (input.Key == ConsoleKey.F1)
            {
                
            }

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

        if (input.Key == ConsoleKey.F1)
        {
            //TODO missing input for executing + function for creating new in database 
            // create a new company
            Clear();
            editor.TextBox("Company Name", "companyName");
            editor.TextBox("Road", "companyRoad");
            editor.TextBox("House Nr.", "companyHouseNumber");
            editor.TextBox("Zip Code", "companyZipCode");
            editor.TextBox("City", "companyCity");
            editor.TextBox("Country", "companyCountry");
            editor.Edit(selected);
            Console.WriteLine($"Company {selected.companyName} is {selected.companyCurrency}");
        }
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
