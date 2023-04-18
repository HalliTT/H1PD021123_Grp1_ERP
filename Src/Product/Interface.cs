using TECHCOOL.UI;

namespace App
{
    public class SetupProductInterface
    {
        public SetupProductInterface(string title, ListPage<Product> list)
        {
            _title = title;
            _list = list;
            _list_selected = new ListPage<Product> {};
            _editor = new Form<Product> {};

            _intrface = new Interface<Product> (_title, 
                                                _list, 
                                                _list_selected, 
                                                _editor);
        }

        protected Interface<Product> _intrface;

        protected string _title = null!;
        public string title
        {
            get { return _title; }
        }

        protected ListPage<Product> _list = null!;
        public ListPage<Product> list
        {
            get { return _list; }
        }

        protected ListPage<Product> _list_selected = null!;
        public ListPage<Product> list_selected
        {
            get { return _list_selected; }
        }
        protected Form<Product> _editor = null!;
        public Form<Product> editor
        {
            get { return _editor; }
        }

        public Screen Show()
        {
            // Preview list interface
            _list.AddColumn("Id", "id");
            _list.AddColumn("Name", "name");
            _list.AddColumn("Amount", "amountInStock");
            _list.AddColumn("Purchase price", "purchasePrice");
            _list.AddColumn("Sales price", "salesPrice");
            _list.AddColumn("Profit", "profit");

            // Selected element interface
            _list_selected.AddColumn("Id", "id");
            _list_selected.AddColumn("Name", "name");
            _list_selected.AddColumn("Description", "description");
            _list_selected.AddColumn("Sales price", "salesPrice");
            _list_selected.AddColumn("Purchase price", "purchasePrice");
            _list_selected.AddColumn("Location", "location");
            _list_selected.AddColumn("Amount", "amountInStock");
            _list_selected.AddColumn("Unit", "unit");
            _list_selected.AddColumn("Profit", "percentageProfit");
            _list_selected.AddColumn("Profit", "profit");

            // Editor interface
            _editor.TextBox("Id", "id");
            _editor.TextBox("Name", "name");
            _editor.TextBox("Description", "description");
            _editor.IntBox("Sales price", "salesPrice");
            _editor.IntBox("Purchase price", "purchasePrice");
            _editor.TextBox("Location", "location");
            _editor.IntBox("Amount", "amountInStock");
            _editor.SelectBox("Unit", "unit");
            _editor.AddOption("Unit", "Pieces", "pieces");
            _editor.AddOption("Unit", "Meters", "meters");
            _editor.AddOption("Unit", "Hours", "hours");

            return _intrface;
        } 
    }
}