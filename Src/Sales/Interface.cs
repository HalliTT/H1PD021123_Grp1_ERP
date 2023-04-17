using TECHCOOL.UI;

namespace App
{
    public class SalesInterface
    {
        public SalesInterface(string title, ListPage<Sales> list)
        {
            this._title = title;
            this._list = list;
            this._list_selected = new ListPage<Sales> {};
            this._editor = new Form<Sales> {};

            this._intrface = new Interface<Sales> (this._title, 
                                                     this._list, 
                                                     this._list_selected, 
                                                     this._editor);
        }

        protected Interface<Sales> _intrface;

        protected string _title = null!;
        public string title
        {
            get { return _title; }
        }

        protected ListPage<Sales> _list = null!;
        public ListPage<Sales> list
        {
            get { return _list; }
        }

        protected ListPage<Sales> _list_selected = null!;
        public ListPage<Sales> list_selected
        {
            get { return _list_selected; }
        }
        protected Form<Sales> _editor = null!;
        public Form<Sales> editor
        {
            get { return _editor; }
        }

        public Screen Show()
        {
            // Preview list interface
            this._list.AddColumn("Id", "id");
            this._list.AddColumn("Creation", "creationTimestamp");
            this._list.AddColumn("Customer Id", "customerId");
            this._list.AddColumn("Name", "fullName");
            this._list.AddColumn("Total", "totalOrderPrice");

            // Selected element interface
            this._list_selected.AddColumn("Id", "id");
            this._list_selected.AddColumn("Date", "creationTimestamp");
            this._list_selected.AddColumn("Customer Id", "customerId");
            this._list_selected.AddColumn("Name", "fullName");
            
            // Editor interface

            return this._intrface;
        } 
    }
}