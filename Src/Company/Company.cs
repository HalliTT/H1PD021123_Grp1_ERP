using System;
using TECHCOOL;
namespace App
{
    public enum Currency
    {
        DKK,
        USD,
        EUR
    };
    public class Company
    {
        /// Constructer
        /// <summary>
        /// Set Company info
        /// </summary>
        public Company(string name, string road, string houseNumber, string zipCode, string city, string country, Currency currency, string cvr, string email)
        {
            this.name = name;
            this.road = road;
            this.houseNumber = houseNumber;
            this.zipCode = zipCode;
            this.city = city;
            this.country = country;
            this.currency = currency;
            this.cvr = cvr;
            this.email = email;
        }

        //Id
        protected int _id;
        public int id
        {
            set { id = value; }
            get { return _id; }
        }

        //Name
        protected string _name;
        public string name
        {
            set { _name = value; }
            get { return _name; }
        }

        //Road
        protected string _road;
        public string road
        {
            set { _road = value; }
            get { return _road; }
        }

        //House Number
        protected string _houseNumber;
        public string houseNumber
        {
            set { _houseNumber = value; }
            get { return _houseNumber; }
        }

        //Zipcode
        protected string _zipCode;
        public string zipCode
        {
            set { _zipCode = value; }
            get { return _zipCode; }
        }

        //City
        protected string _city;
        public string city
        {
            set { _city = value; }
            get { return _city; }
        }

        //Country
        protected string _country;
        public string country
        {
            set { _country = value; }
            get { return _country; }
        }

        //Currency
        protected Currency _currency;
        public Currency currency
        {
            set { _currency = value; }
            get { return _currency; }
        }

        //CVR
        protected string _cvr;
        public string cvr
        {
            set { _cvr = value; }
            get { return _cvr; }
        }

        //Customer Service Email
        protected string _email;
        public string email
        {
            set { _email = value; }
            get { return _email; }
        }
    }
}