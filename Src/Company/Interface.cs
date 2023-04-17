using TECHCOOL.UI;

namespace App
{
    public class CompanyInterface
    {
        public CompanyInterface(string title, ListPage<Company> list)
        {
            this._title = title;
            this._list = list;
            this._list_selected = new ListPage<Company> {};
            this._editor = new Form<Company> {};

            this._intrface = new Interface<Company> (this._title, 
                                                     this._list, 
                                                     this._list_selected, 
                                                     this._editor);
        }

        protected Interface<Company> _intrface;

        protected string _title = null!;
        public string title
        {
            get { return _title; }
        }

        protected ListPage<Company> _list = null!;
        public ListPage<Company> list
        {
            get { return _list; }
        }

        protected ListPage<Company> _list_selected = null!;
        public ListPage<Company> list_selected
        {
            get { return _list_selected; }
        }
        protected Form<Company> _editor = null!;
        public Form<Company> editor
        {
            get { return _editor; }
        }

        public void Show()
        {
            // Preview list interface
            this._list.AddColumn("Name", "name");
            this._list.AddColumn("Country", "country");
            this._list.AddColumn("Currency", "currency");

            // Selected element interface
            this._list_selected.AddColumn("Name", "name");
            this._list_selected.AddColumn("Road", "road");
            this._list_selected.AddColumn("House number", "houseNumber");
            this._list_selected.AddColumn("Zipcode", "zipCode");
            this._list_selected.AddColumn("City", "city");
            this._list_selected.AddColumn("Country", "country");
            this._list_selected.AddColumn("Currency", "currency");
            this._list_selected.AddColumn("CVR", "cvr");
            this._list_selected.AddColumn("Email", "email");

            // Editor interface
            this._editor.TextBox("Name", "name");
            this._editor.TextBox("Road", "road");
            this._editor.TextBox("House Nr.", "houseNumber");
            this._editor.TextBox("Zip Code", "zipCode");
            this._editor.TextBox("City", "city");
            this._editor.TextBox("Country", "country");
            this._editor.SelectBox("Currency", "currency");
            this._editor.AddOption("Currency", "USD", "USD");
            this._editor.AddOption("Currency", "DKK", "DKK");
            this._editor.AddOption("Currency", "EUR", "EUR");
            this._editor.TextBox("CVR", "cvr");
            this._editor.TextBox("Email", "email");

            Screen.Display(this._intrface);
        } 

    }
}