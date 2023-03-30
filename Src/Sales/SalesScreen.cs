using System;
using TECHCOOL;
using TECHCOOL.UI;

namespace App
{
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