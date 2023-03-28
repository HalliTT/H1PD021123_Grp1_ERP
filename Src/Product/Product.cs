using System;
using System.Runtime.CompilerServices;
using TECHCOOL;

namespace App
{
    public enum Unit { pieces, meters, hours }
    public class Product
    {
        public Product(string productId, string name, decimal purchasePrice, decimal salesPrice, string location, float amountInStock, Unit unit)
        {
            this.productId = productId;
            this.name = name;
            this.purchasePrice = purchasePrice;
            this.salesPrice = salesPrice;
            this.location = location;
            this.amountInStock = amountInStock;
            this.unit = unit;
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
        protected static decimal _purchasePrice;
        public decimal purchasePrice
        {
            set { _purchasePrice = value; }
            get { return _purchasePrice; }
        }
        //salesprice 
        protected static decimal _salesPrice;
        public decimal salesPrice
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

        public static decimal calculateProfit(decimal salesPrice, decimal purchasePrice)
        {
            decimal profit = purchasePrice - salesPrice;
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

        public static decimal getProfitInPercentage() { 

           decimal profit = Product._purchasePrice  / Product.calculateProfit(Product._purchasePrice, Product._salesPrice) * 100;;
           return profit;
        }
    }
}
