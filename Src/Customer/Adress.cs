using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    /// 
    /// Adress used in Person
    ///
    public class Adress
    {
        //Constructor
        public Adress(string country, string zipCode, string city, string roadName, string doorNumber)
        {
            this.country = country;
            this.zipCode = zipCode;
            this.city = city;
            this.roadName = roadName;
            this.doorNumber = doorNumber;
        }

        //Country
        protected string _country;
        public string country
        {
            get { return _country; }
            set { _country = value; }
        }

        //Zip
        protected string _zipCode;
        public string zipCode
        {
            get { return _zipCode; }
            set { _zipCode = value; }
        }

        //City
        protected string _city;
        public string city
        {
            get { return _city; }
            set { _city = value; }
        }

        //Road
        protected string _roadName;
        public string roadName
        {
            get { return _roadName; }
            set { _roadName = value; }
        }

        //Door
        protected string _doorNumber;
        public string doorNumber
        {
            get { return _doorNumber; }
            set { _doorNumber = value; }
        }
    }
}
