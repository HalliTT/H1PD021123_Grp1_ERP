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
    }
}