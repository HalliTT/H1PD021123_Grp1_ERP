using TECHCOOL.UI;

namespace App
{
    public class ProductInterface
    {
        public ProductInterface(string title, ListPage<Product> list)
        {
            this._title = title;
            this._list = list;
            this._list_selected = new ListPage<Product> {};
            this._editor = new Form<Product> {};

            this._intrface = new Interface<Product> (this._title, 
                                                     this._list, 
                                                     this._list_selected, 
                                                     this._editor);
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

        public void Show()
        {
            // Preview list interface
            this._list.AddColumn("Id", "id");
            this._list.AddColumn("Name", "name");
            this._list.AddColumn("Amount", "amountInStock");
            this._list.AddColumn("Purchase price", "purchasePrice");
            this._list.AddColumn("Sales price", "salesPrice");
            this._list.AddColumn("Profit", "profit");

            // Selected element interface
            this._list_selected.AddColumn("Id", "id");
            this._list_selected.AddColumn("Name", "name");
            this._list_selected.AddColumn("Description", "description");
            this._list_selected.AddColumn("Sales price", "salesPrice");
            this._list_selected.AddColumn("Purchase price", "purchasePrice");
            this._list_selected.AddColumn("Location", "location");
            this._list_selected.AddColumn("Amount", "amountInStock");
            this._list_selected.AddColumn("Unit", "unit");
            this._list_selected.AddColumn("Profit", "percentageProfit");
            this._list_selected.AddColumn("Profit", "profit");

            // Editor interface
            this._editor.TextBox("Id", "id");
            this._editor.TextBox("Name", "name");
            this._editor.TextBox("Description", "description");
            this._editor.IntBox("Sales price", "salesPrice");
            this._editor.IntBox("Purchase price", "purchasePrice");
            this._editor.TextBox("Location", "location");
            this._editor.IntBox("Amount", "amountInStock");
            this._editor.SelectBox("Unit", "unit");
            this._editor.AddOption("Unit", "Pieces", "pieces");
            this._editor.AddOption("Unit", "Meters", "meters");
            this._editor.AddOption("Unit", "Hours", "hours");

            Screen.Display(this._intrface);
        } 

    }
}