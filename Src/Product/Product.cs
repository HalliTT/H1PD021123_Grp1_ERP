using System;
using TECHCOOL;

namespace App
{
    public enum Unit { pieces, meters, hours }
    public class Product
    {
        public Product(string name, string description, double purchasePrice, double salesPrice, string location, double amountInStock, Unit unit)
        {
            _name = name;
            _description = description;
            _purchasePrice = purchasePrice;
            _salesPrice = salesPrice;
            _location = location;
            _amountInStock = amountInStock;
            _unit = unit;

        }

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

        protected string _location = null!;
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

        public string profit
        {
            get { return CalcProfit(); }
        }

        public string percentageProfit
        {
            get { return CalcPercentageProfit(); }
        }
        protected string _description = null!;
        public string description
        {
            set { _description = value; }
            get { return _description; }
        }

        public string CalcProfit()
        {
            return Convert.ToString(_salesPrice - _purchasePrice) + " kr";
        }

        public string CalcPercentageProfit()
        {
            var profit = (_salesPrice - _purchasePrice) / _salesPrice * 100;
            return profit.ToString() + " %";
        }
    }
}