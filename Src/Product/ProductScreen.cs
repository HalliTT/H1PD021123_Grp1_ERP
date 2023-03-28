using App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TECHCOOL.UI;

namespace App
{
    public class ProductScreen : Screen
    {
        public override string Title { get; set; } = "Product List";

        protected override void Draw()
        {
            Clear(this);
           ListPage<Product> listPage = new ListPage<Product>();

            listPage.Add(new Product("#001", "Ribbon", 30, 49.99, "Danmark", 50, Unit.pieces));
            listPage.AddColumn("Product ID", "productId");
            listPage.AddColumn("Product Name", "name");
            listPage.AddColumn("Purchase Price", "purchasePrice");
            listPage.AddColumn("Sales Price", "salesPrice");
           

            Product selected = listPage.Select();
            Console.WriteLine("You Selected: " + selected);
        }
    }
}

