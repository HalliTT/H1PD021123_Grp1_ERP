using System;
using TECHCOOL;

namespace App
{
    public enum Unit { pieces, meters, hours }
    public class Product
    {
        public Product(string name, string description, double purchasePrice, double salesPrice, string location, float amountInStock, Unit unit)
        {
            this.name = name;
            this.description = description;
            this.purchasePrice = purchasePrice;
            this.salesPrice = salesPrice;
            this.location = location;
            this.amountInStock = amountInStock;
            this.unit = unit;

            this._profit = CalcProfit();
            this._percentageProfit = CalcPercentageProfit();
        }

        public Product() {}

        protected int _Id;
        public int Id
        {
            set { _Id = value; }
            get { return _Id; }
        }

        protected string _name;
        public string name
        {
            set { _name = value; }
            get { return _name; }
        }

        protected double _purchasePrice;
        public double purchasePrice
        {
            set { _purchasePrice = value; }
            get { return _purchasePrice; }
        }

        protected double _salesPrice;
        public double salesPrice
        {
            set { _salesPrice = value; }
            get { return _salesPrice; }
        }

        protected string _location;
        public string location
        {
            set { _location = value; }
            get { return _location; }
        }

        protected double _amountInStock;
        public double amountInStock
        {
            set { _amountInStock = value; }
            get { return _amountInStock; }
        }

        protected Unit _unit;
        public Unit unit
        {
            set { _unit = value; }
            get { return _unit; }
        }

        protected string _profit;
        public string profit
        {
            get { return _profit; }
        }

        protected string _percentageProfit;
        public string percentageProfit
        {
            get { return _percentageProfit; }
        }
        protected string _description;
        public string description
        {
            set { _description = value; }
            get { return _description; }
        }

        public string CalcProfit()
        {
            return Convert.ToString(this.salesPrice - this.purchasePrice) + " kr";
        }

        public string CalcPercentageProfit()
        {
            var profit = (this.salesPrice - this.purchasePrice) / this.salesPrice * 100;
            return profit.ToString() + " %";
        }
    }
}