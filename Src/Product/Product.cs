using System;
using TECHCOOL;

namespace App
{
    public enum Unit { piece, meter, hour }
    public class Product
    {
        private string ProductId { get; set; }
        protected string Name { get; set; }
        double PurchasePrice { get; set; }
        double SalesPrice { get; set; }
        string Location { get; set; }
        float AmountInStock { get; set; }
        Unit Unit { get; set; }

        public Product(string ProductId, string Name, int Amount, double PurchasePrice, double SalesPrice, string Location, float AmountInStock, Unit Unit)
        {
            this.ProductId = ProductId;
            this.Name = Name;
            this.PurchasePrice = PurchasePrice;
            this.SalesPrice = SalesPrice;
            this.Location = Location;
            this.AmountInStock = AmountInStock;
            this.Unit = (Unit)Unit;
        }
        //id 
        protected string _productId;
        protected string productId
        {
            set { _productId = value; }
            get { return _productId; }
        }
        //name 
        protected string _name;
        protected string name
        {
            set { _name = value; }
            get { return _name; }
        }
        //purchaseprice 
        protected double _purchaseprice;
        protected double purchaseprice
        {
            set { _purchaseprice = value; }
            get { return _purchaseprice; }
        }
        //salesprice 
        protected double _salesprice;
        protected double salesprice
        {
            set { _salesprice = value; }
            get { return _salesprice; }
        }
        //Location 
        protected string _location;
        protected string location
        {
            set { _location = value; }
            get { return _location; }
        }
        //AmountInStock 
        protected double _amountinstock;
        protected double amountinstock
        {
            set { _amountinstock = value; }
            get { return _amountinstock; }
        }
        //Unit 
        protected Unit _unit;
        protected Unit unit
        {
            set { _unit = value; }
            get { return _unit; }
        }

        public double calculateProfit()
        {
            double profit = this.PurchasePrice - this.SalesPrice;
            return profit;
        }
        public double Margin()
        {
            int test = 0;
            foreach (var i in ProductId)
            {
                test++;
            }
            return test;
            //TODO double profitMargin = (PurchasePrice / SalesPrice) * 100;
        }
    }
}
