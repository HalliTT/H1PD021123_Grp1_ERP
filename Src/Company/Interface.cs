using TECHCOOL.UI;

namespace App
{
    public class CompanyInterface
    {
        public CompanyInterface(string title, ListPage<Company> list)
        {
            _title = title;
            _list = list;
            _list_selected = new ListPage<Company> {};
            _editor = new Form<Company> {};

            _intrface = new Interface<Company> (_title, 
                                                     _list, 
                                                     _list_selected, 
                                                     _editor);
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

        public Screen Show()
        {
            // Preview list interface
            _list.AddColumn("Name", "name");
            _list.AddColumn("Country", "country");
            _list.AddColumn("Currency", "currency");

            // Selected element interface
            _list_selected.AddColumn("Name", "name");
            _list_selected.AddColumn("Road", "road");
            _list_selected.AddColumn("House number", "houseNumber");
            _list_selected.AddColumn("Zipcode", "zipCode");
            _list_selected.AddColumn("City", "city");
            _list_selected.AddColumn("Country", "country");
            _list_selected.AddColumn("Currency", "currency");
            _list_selected.AddColumn("CVR", "cvr");
            _list_selected.AddColumn("Email", "email");

            // Editor interface
            _editor.TextBox("Name", "name");
            _editor.TextBox("Road", "road");
            _editor.TextBox("House Nr.", "houseNumber");
            _editor.TextBox("Zip Code", "zipCode");
            _editor.TextBox("City", "city");
            _editor.TextBox("Country", "country");
            _editor.SelectBox("Currency", "currency");
            _editor.AddOption("Currency", "USD", "USD");
            _editor.AddOption("Currency", "DKK", "DKK");
            _editor.AddOption("Currency", "EUR", "EUR");
            _editor.TextBox("CVR", "cvr");
            _editor.TextBox("Email", "email");

            return _intrface;
        } 

    }
}