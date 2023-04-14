using System.CodeDom;
using TECHCOOL.UI;

namespace App
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var list = new ListPage<Product> {};

            list.AddColumn("Id", "Id");
            list.AddColumn("Name", "name");

            var product = new Product("product", "test", 10, 100, "DK", 2, Unit.meters);
            list.Add(product);

            var selected = new ListPage<Product> {};

            selected.AddColumn("Id", "Id");
            selected.AddColumn("Name", "name");
            selected.AddColumn("Description", "description");
            selected.AddColumn("Sales price", "salesPrice");
            selected.AddColumn("Purchase price", "purchasePrice");
            selected.AddColumn("Location", "location");

            var form = new Form<Product> {};

            form.TextBox("Name", "name");

            var screen = new Interface<Product> ("Product list", list, selected, form);
            Screen.Display(screen);

            screen.Create();
        }
    }
}

