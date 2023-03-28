using App;
using H1PD021123_Grp1_ERP.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
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

            listPage.Add(new Product("#001", "Ribbon", 30, 49.99, "Danmark", 50, Unit.pieces)); //TODO: Delete test data
            listPage.AddColumn("Product ID", "productId");
            listPage.AddColumn("Product Name", "name");
            listPage.AddColumn("Purchase Price", "purchasePrice");
            listPage.AddColumn("Sales Price", "salesPrice");
           

            Product selected = listPage.Select();
            Console.WriteLine("You Selected: " + selected);

            
            if (selected != null ) //Not sure its gonna work later on, might need a change
            {
                ProductDescription screen = new ProductDescription();
                Screen.Display(screen);
            }
                
        }
    }

    public class ProductDescription : Screen
    {
        public override string Title { get; set; } = "Product Description";

        protected override void Draw()
        {
            Clear(this);
            ListPage<ProductDescriprion> list = new ListPage<ProductDescriprion>();
            list.Add(new ProductDescriprion(
                        "#001",
                        "Ribbon",
                        "This is a ribbon",
                        50.00,
                        30.00,
                        "Danmark",
                        100.00,
                        50 + Unit.meters,
                        50,
                        50
                        ));//TODO Delete test data
            list.AddColumn("Product ID", "productId");
            list.AddColumn("Product Name", "productName");
            list.AddColumn("Prouduct Description", "productDescription");
            list.AddColumn("Sales Price", "salesPrice");
            list.AddColumn("Purchase Price", "purchasePrice");
            list.AddColumn("Location", "location");
            list.AddColumn("Quantity", "quantity");
            list.AddColumn("Unit", "unit");
            list.AddColumn("Profit in %", "profitInPercentage");
            list.AddColumn("Profit in DKK", "profitInDkk");

            ProductDescriprion selected = list.Select();

        }

    }
}

