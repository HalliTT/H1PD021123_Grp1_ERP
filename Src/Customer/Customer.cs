using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using H1PD021123_Grp1_ERP.Entities;

namespace App
{
    public class Person
    {
        private string customerID { get; set; }

        private string lastOrderDate = DateTime.Now.ToString();
        public string CustomerID
        {
            get { return customerID; }
            set { customerID = value; }
        }

        public string LastOrderDate
        {
            get { return lastOrderDate; }
            set { lastOrderDate = value; }
        }


    }
}
