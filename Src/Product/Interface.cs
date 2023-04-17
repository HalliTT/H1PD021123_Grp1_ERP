using TECHCOOL.UI;

namespace App
{
    public class ProductInterface
    {
        public ProductInterface(string title,
                                ListPage<Product> list, 
                                ListPage<Product> list_selected, 
                                Form<Product> editor)
        {
            this._title = title;
            this._list = list;
            this._list_selected = list_selected;
            this._editor = editor;

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
            this._list.AddColumn("Id", "Id");
            this._list.AddColumn("Name", "name");
            this._list.AddColumn("Amount", "amountInStock");
            this._list.AddColumn("Purchase price", "purchasePrice");
            this._list.AddColumn("Sales price", "salesPrice");
            this._list.AddColumn("Profit", "profit");

            // Selected element interface
            this._list_selected.AddColumn("Id", "Id");
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

            Screen.Display(this._intrface);
        } 

    }
}