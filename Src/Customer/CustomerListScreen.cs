using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TECHCOOL.UI;

namespace H1PD021123_Grp1_ERP.Screens
{
    public class CustomerListScreen : Screen
    {
        public override string Title { get; set; } = "Customer List";

        protected override void Draw()
        {
            Clear(this);
            ListPage<CustomerList> list = new ListPage<CustomerList>();
            list.Add(new CustomerList("#8123", "Sebastian Wrobel", "+45 34 34 34 34", "sebastian@kutas.pl"));

            

            CustomerList selected = list.Select();
            Console.WriteLine("You selected: " + selected);

        }
    }
}
