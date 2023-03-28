using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1PD021123_Grp1_ERP.Entities
{
    public class Adress
    {
        private string roadName;
        private string doorNumber;
        private string zipCode;
        private string state;
        private string city;

        public string getRoadName
        {
            get { return roadName; }
            set { roadName = value; }
        }

        public string getDoorNumber
        {
            get { return doorNumber; }
            set { doorNumber = value; }
        }

        public string getZipCode
        {
            get { return zipCode; }
            set { zipCode = value; }
        }

        public string getState
        {
            get { return state; }
            set { state = value; }
        }

        public string getCity
        {
            get { return city; }
            set { city = value; }
        }
    }
}
