using System;
using TECHCOOL;
using TECHCOOL.UI;

namespace App
{
    public class SalesFullListScreen : Screen
    {
        public override string Title { get; set; } = "List of sales";
        protected override void Draw()
        {
            Clear(this);
            ListPage<Sales> listSales = new ListPage<Sales>();
            // listSales.Add(new Sales("700", "128", "128", "22", "asdas", "asdsd", "sdas"));
            listSales.AddColumn("Id", "companyId");
            listSales.AddColumn("Company", "companyName");
            listSales.AddColumn("Road", "companyRoad");
            listSales.AddColumn("House Number", "companyHouseNumber");
            listSales.AddColumn("Zip Code", "companyZipCode");
            listSales.AddColumn("City", "companyCity");
            listSales.AddColumn("Country", "companyCountry");
            listSales.AddColumn("Currency", "companyCurrency");
            listSales.AddColumn("CVR", "companyCvr");
            listSales.AddColumn("Email", "companyEmail");
            listSales.Draw();
        }
    }
}