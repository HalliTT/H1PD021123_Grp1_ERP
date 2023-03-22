using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1PD021123_Grp1_ERP.Screens
{
    class CustomerList
    {
        public string CustomerID { get; set; } = "";
        public string CustomerName { get; set; } = "";
        public string CustomerPhone { get; set; } = "";
        public string CustomerMail { get; set; } = "";  

        public CustomerList(string customerId, string customerName, string customerPhone, string customerMail) 
        {
            CustomerID = customerId;
            CustomerName = customerName;
            CustomerPhone = customerPhone;
            CustomerMail = customerMail;
        }
    }
}
