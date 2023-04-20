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
            _name = name;
            _road = road;
            _houseNumber = houseNumber;
            _zipCode = zipCode;
            _city = city;
            _country = country;
            _currency = currency;
            _cvr = cvr;
            _email = email;
        }
        
        //Id
        protected int _id;
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }

        protected string _name = null!;
        public string name
        {
            set { _name = value; }
            get { return _name; }
        }

        protected string _road = null!;
        public string road
        {
            set { _road = value; }
            get { return _road; }
        }

        protected string _houseNumber = null!;
        public string houseNumber
        {
            set { _houseNumber = value; }
            get { return _houseNumber; }
        }

        protected string _zipCode = null!;
        public string zipCode
        {
            set { _zipCode = value; }
            get { return _zipCode; }
        }

        protected string _city = null!;
        public string city
        {
            set { _city = value; }
            get { return _city; }
        }

        protected string _country = null!;
        public string country
        {
            set { _country = value; }
            get { return _country; }
        }

        protected Currency _currency;
        public Currency currency
        {
            set { _currency = value; }
            get { return _currency; }
        }

        protected string _cvr = null!;
        public string cvr
        {
            set { _cvr = value; }
            get { return _cvr; }
        }

        protected string _email = null!;
        public string email
        {
            set { _email = value; }
            get { return _email; }
        }
    }
}