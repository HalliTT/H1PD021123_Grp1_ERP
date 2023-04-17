using System.CodeDom;
using TECHCOOL.UI;

namespace App
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var list = new ListPage<Product> {};

            var product = new Product("product", "test", 10, 100, "DK", 2, Unit.meters);
            list.Add(product);

            var selected = new ListPage<Product> {};

            var form = new Form<Product> {};

            form.TextBox("Name", "name");

            var screen = new ProductInterface ("Product list", list, selected, form);
            screen.Show();
        }
    }
}

