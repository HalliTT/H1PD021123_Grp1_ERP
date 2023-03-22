using System;
using TECHCOOL;

namespace App.Product
{
    public class Product
    {
            private string ProductId { get; set; }
            protected string Name { get; set; }
            int Amount { get; set; }
            double PurchasePrice { get; set; }
            double SalesPrice { get; set; }
            double Unit {get ; set; }

        public Product(string ProductId, string Name, int Amount, double PurchasePrice, double SalesPrice, double Unit)
        {
            this.ProductId = ProductId;
            this.Name = Name;
            this.Amount = Amount;
            this.PurchasePrice = PurchasePrice;
            this.SalesPrice = SalesPrice;
            this.Unit = Unit;
        }


        public void calculateProfit(double PurchasePrice, double SalesPrice)
            {
            //double purchasePrice = PurchasePrice;
            //double salesPrice = SalesPrice;
            double profit = PurchasePrice - SalesPrice;
            foreach (var i in ProductId)
                {
                    
                }
            double profitMargin = (PurchasePrice / SalesPrice) * 100;
            }
        }
}