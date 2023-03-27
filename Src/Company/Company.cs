using System;
using TECHCOOL;
namespace App
{
    internal class Company
    {
        /// Constructer
        /// <summary>
        /// Set Company info
        /// </summary>
        public Company(string companyId, string companyName, string companyRoad, string companyHouseNumber, string companyZipCode, string companyCity, string companyCountry, string companyCurrency, string companyCvr, string companyEmail)
        {
            this.companyId = companyId;
            this.companyName = companyName;
            this.companyRoad = companyRoad;
            this.companyHouseNumber = companyHouseNumber;
            this.companyZipCode = companyZipCode;
            this.companyCity = companyCity;
            this.companyCountry = companyCountry;
            this.companyCurrency = companyCurrency;
            this.companyCvr = companyCvr;
            this.companyEmail = companyEmail;
        }

        //Id
        protected string _companyId;
        public string companyId
        {
            set { _companyId = value; }
            get { return _companyId; }
        }

        //Name
        protected string _companyName;
        public string companyName
        {
            set { _companyName = value; }
            get { return _companyName; }
        }

        //Road
        protected string _companyRoad;
        public string companyRoad
        {
            set { _companyRoad = value; }
            get { return _companyRoad; }
        }

        //House Number
        protected string _companyHouseNumber;
        public string companyHouseNumber
        {
            set { _companyHouseNumber = value; }
            get { return _companyHouseNumber; }
        }

        //Zipcode
        protected string _companyZipCode;
        public string companyZipCode
        {
            set { _companyZipCode = value; }
            get { return _companyZipCode; }
        }

        //City
        protected string _companyCity;
        public string companyCity
        {
            set { _companyCity = value; }
            get { return _companyCity; }
        }

        //Country
        protected string _companyCountry;
        public string companyCountry
        {
            set { _companyCountry = value; }
            get { return _companyCountry; }
        }

        //Currency
        protected string _companyCurrency;
        public string companyCurrency
        {
            set { _companyCurrency = value; }
            get { return _companyCurrency; }
        }

        //CVR
        protected string _companyCvr;
        public string companyCvr
        {
            set { _companyCvr = value; }
            get { return _companyCvr; }
        }

        //Customer Service Email
        protected string _companyEmail;
        public string companyEmail
        {
            set { _companyEmail = value; }
            get { return _companyEmail; }
        }
    }
}