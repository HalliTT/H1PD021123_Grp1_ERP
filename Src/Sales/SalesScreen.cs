using System;
using TECHCOOL;
using TECHCOOL.UI;

namespace App
{
    public class SalesFullListScreen : Screen
    {
        public SalesFullListScreen(ListPage<Sales> nnlist)
        {
            this.salesList = nnlist;
        }

        protected ListPage<Sales> _salesList;
        public ListPage<Sales> salesList
        {
            set { _salesList = value; }
            get { return _salesList; }
        }

        public override string Title { get; set; } = "List of sales";
        protected override void Draw()
        {
            Clear(this);
            salesList.AddColumn("orderNumber", "orderNumber", 20);
            salesList.AddColumn("creationTimestamp", "creationTimestamp", 20);
            salesList.AddColumn("customerNumber", "customerNumber", 20);
            salesList.AddColumn("totalOrderPrice", "totalOrderPrice", 20);

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
                listSales.AddColumn("Sales Order Number", "orderNumber", 20);
                listSales.AddColumn("Date", "creationTimestamp", 20);
                listSales.AddColumn("Customer Id", "customerNumber", 20);
                listSales.Draw();
            }

        }
    }
}