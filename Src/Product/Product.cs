using System;
using TECHCOOL;

namespace App
{
    public enum Unit { pieces, meters, hours }
    public class Product
    {
        public Product(string productId, string name, double purchasePrice, double salesPrice, string location, float amountInStock, Unit Unit)
        {
            this.productId = productId;
            this.name = name;
            this.purchasePrice = purchasePrice;
            this.salesPrice = salesPrice;
            this.location = location;
            this.amountInStock = amountInStock;
            this.unit = (Unit)Unit;
        }
        //id 
        protected string _productId;
        public string productId
        {
            set { _productId = value; }
            get { return _productId; }
        }
        //name 
        protected string _name;
        public string name
        {
            set { _name = value; }
            get { return _name; }
        }
        //purchaseprice 
        protected double _purchasePrice;
        public double purchasePrice
        {
            set { _purchasePrice = value; }
            get { return _purchasePrice; }
        }
        //salesprice 
        protected double _salesPrice;
        public double salesPrice
        {
            set { _salesPrice = value; }
            get { return _salesPrice; }
        }
        //Location 
        protected string _location;
        public string location
        {
            set { _location = value; }
            get { return _location; }
        }
        //AmountInStock 
        protected double _amountInStock;
        public double amountInStock
        {
            set { _amountInStock = value; }
            get { return _amountInStock; }
        }
        //Unit 
        protected Unit _unit;
        public Unit unit
        {
            set { _unit = value; }
            get { return _unit; }
        }

        public double calculateProfit()
        {
            double profit = this.purchasePrice - this.salesPrice;
            return profit;
        }
        public double Margin()
        {
            int test = 0;
            foreach (var i in productId)
            {
                test++;
            }
            return test;
            //TODO double profitMargin = (PurchasePrice / SalesPrice) * 100;
        }
    }
}
