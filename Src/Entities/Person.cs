using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1PD021123_Grp1_ERP.Entities
{
    public class Person
    {
        string name;
        string surname;
        private Adress adress;
        private string phoneNumber;



        public string getName
        {
            get { return name; }
            set { name = value; }
        }

        public string getSurname
        {
            get { return surname; }
            set { surname = value; }
        }

        public string getPhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public string getFullName()
        {
            string fullname = name + " " + surname;
            return fullname;

        }
    }
}
