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
        public Company(Guid id, string name, string road, string houseNumber, string zipCode, string city, string country, Currency currency, string cvr, string email)
        {
            this.id = this.id;
            this.name = this.name;
            this.road = this.road;
            this.houseNumber = this.houseNumber;
            this.zipCode = this.zipCode;
            this.city = this.city;
            this.country = this.country;
            this.currency = this.currency;
            this.cvr = this.cvr;
            this.email = this.email;
        }

        //Id
        protected string _id;
        public string id
        {
            set { id = value; }
            get { return _id; }
        }

        //Name
        protected string _name;
        public string name
        {
            set { name = value; }
            get { return _name; }
        }

        //Road
        protected string _road;
        public string road
        {
            set { road = value; }
            get { return _road; }
        }

        //House Number
        protected string _houseNumber;
        public string houseNumber
        {
            set { houseNumber = value; }
            get { return _houseNumber; }
        }

        //Zipcode
        protected string _zipCode;
        public string zipCode
        {
            set { zipCode = value; }
            get { return _zipCode; }
        }

        //City
        protected string _city;
        public string city
        {
            set { city = value; }
            get { return _city; }
        }

        //Country
        protected string _country;
        public string country
        {
            set { country = value; }
            get { return _country; }
        }

        //Currency
        protected Currency _currency;
        public Currency currency
        {
            set { currency = value; }
            get { return _currency; }
        }

        //CVR
        protected string _cvr;
        public string cvr
        {
            set { cvr = value; }
            get { return _cvr; }
        }

        //Customer Service Email
        protected string _email;
        public string email
        {
            set { email = value; }
            get { return _email; }
        }
    }
}