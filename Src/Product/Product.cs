using System;
using TECHCOOL;

namespace App
{
    public enum Unit { pieces, meters, hours }
    public class Product
    {
        public Product(string name, string description, double purchasePrice, double salesPrice, string location, float amountInStock, Unit unit)
        {
            _name = name;
            _description = description;
            _purchasePrice = purchasePrice;
            _salesPrice = salesPrice;
            _location = location;
            _amountInStock = amountInStock;
            _unit = unit;

            _profit = CalcProfit();
            _percentageProfit = CalcPercentageProfit();
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
            get { return _name; }
        }

        protected double _purchasePrice;
        public double purchasePrice
        {
            get { return _purchasePrice; }
        }

        protected double _salesPrice;
        public double salesPrice
        {
            get { return _salesPrice; }
        }

        protected string _location = null!;
        public string location
        {
            get { return _location; }
        }

        protected double _amountInStock;
        public double amountInStock
        {
            get { return _amountInStock; }
        }

        protected Unit _unit;
        public Unit unit
        {
            get { return _unit; }
        }

        protected string _profit = null!;
        public string profit
        {
            get { return _profit; }
        }

        protected string _percentageProfit = null!;
        public string percentageProfit
        {
            get { return _percentageProfit; }
        }
        protected string _description = null!;
        public string description
        {
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