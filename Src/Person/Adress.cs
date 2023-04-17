﻿using System.Text;

namespace App
{
    /// 
    /// Address used in Person
    ///
    public class Address
    {
        //Constructor
        public Address(string country, string zipCode, string city, string roadName, string doorNumber)
        {
            this.country = country;
            this.zipCode = zipCode;
            this.city = city;
            this.roadName = roadName;
            this.doorNumber = doorNumber;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            return sb.AppendFormat($"{this._roadName}, {this._doorNumber}, {this._zipCode}, {this._city}").ToString();
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
