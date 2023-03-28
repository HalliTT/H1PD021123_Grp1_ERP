using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public class CustomerList
    {
        //Constructort
        public CustomerList(uint customerId, string customerFullName, string customerPhone, string customerMail)
        {
            CustomerID = customerId;
            CustomerFullName = customerFullName;
            CustomerPhone = customerPhone;
            CustomerMail = customerMail;
        }

        //Id
        protected uint _customerId;
        public uint CustomerID
        {
            set { _customerId = value; }
            get { return _customerId; }
        }

        //Name
        protected string _customerFullName;
        public string CustomerFullName
        {
            set { _customerFullName = value; }
            get { return _customerFullName; }
        }

        //Phone
        protected string _customerPhone;
        public string CustomerPhone
        {
            set { _customerPhone = value; }
            get { return _customerPhone; }
        }

        //Email
        protected string _customerMail;
        public string CustomerMail
        {
            set { _customerMail = value; }
            get { return _customerMail; }
        }
    }
}
