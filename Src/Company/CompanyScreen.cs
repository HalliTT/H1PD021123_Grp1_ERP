using System;
using TECHCOOL;
using TECHCOOL.UI;
namespace App
{

    public class CompanyFullListScreen : Screen
    {
        public override string Title { get; set; } = "List of Companies";
        protected override void Draw()
        {
            Clear(this); //Clean the screen
            ListPage<Company.Company> listCompany = new ListPage<Company.Company>();
            listCompany.Add(new Company.Company("200", "Venus", "Landevejen", "2", "9000", "Aalborg", "Denmark", "Dkk", "29 54 90 22", "Venus@venus.dk"));
            listCompany.Add(new Company.Company("700", "Mars", "Hovedvejen", "88", "9200", "Nørresundby", "Denmark", "Dkk", "29 22 00 10", "Mars@Mars.dk"));
            listCompany.AddColumn("Id", "companyId");
            listCompany.AddColumn("Company", "companyName");
            listCompany.AddColumn("Road", "companyRoad");
            listCompany.AddColumn("House Number", "companyHouseNumber");
            listCompany.AddColumn("Zip Code", "companyZipCode");
            listCompany.AddColumn("City", "companyCity");
            listCompany.AddColumn("Country", "companyCountry");
            listCompany.AddColumn("Currency", "companyCurrency");
            listCompany.AddColumn("CVR", "companyCvr");
            listCompany.AddColumn("Email", "companyEmail");

            listCompany.Draw();
        }
    }

    public class CompanyShortListScreen : Screen
    {
        public override string Title { get; set; } = "List of Companies";
        protected override void Draw()
        {
            Clear(this); //Clean the screen
            ListPage<Company.Company> listCompany = new ListPage<Company.Company>();
            listCompany.Add(new Company.Company("200", "Venus", "Landevejen", "2", "9000", "Aalborg", "Denmark", "Dkk", "29 54 90 22", "Venus@venus.dk"));
            listCompany.Add(new Company.Company("700", "Mars", "Hovedvejen", "88", "9200", "Nørresundby", "Denmark", "Dkk", "29 22 00 10", "Mars@Mars.dk"));
            listCompany.AddColumn("Company", "companyName");
            listCompany.AddColumn("Country", "companyCountry");
            listCompany.AddColumn("Currency", "companyCurrency");
            listCompany.Draw();
        }
    }
}