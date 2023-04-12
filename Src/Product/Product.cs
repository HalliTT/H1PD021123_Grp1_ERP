using System;
using TECHCOOL;

namespace App
{
    public enum Unit { pieces, meters, hours }
    public class Product
    {
        public Product(Guid productId, string name, double purchasePrice, double salesPrice, string location, float amountInStock, Unit unit)
        {
            this.productId = productId;
            this.name = name;
            this.purchasePrice = purchasePrice;
            this.salesPrice = salesPrice;
            this.location = location;
            this.amountInStock = amountInStock;
            this.unit = unit;

            this._profit = calcProfit();
        }

        protected Guid _productId;
        public Guid productId
        {
            set { _productId = value; }
            get { return _productId; }
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

        public string calcProfit()
        {
            var profit = (this.salesPrice - this.purchasePrice) / this.salesPrice * 100;
            return profit.ToString() + " %";
        }
    }
}