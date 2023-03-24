using System;
using TECHCOOL;

namespace App
{
    public enum Unit { meter, }
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
