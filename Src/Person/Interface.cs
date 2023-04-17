using TECHCOOL.UI;

namespace App
{
    public class PersonInterface
    {
        public PersonInterface(string title, ListPage<Person> list)
        {
            this._title = title;
            this._list = list;
            this._list_selected = new ListPage<Person> {};
            this._editor = new Form<Person> {};

            this._intrface = new Interface<Person> (this._title, 
                                                     this._list, 
                                                     this._list_selected, 
                                                     this._editor);
        }

        protected Interface<Person> _intrface;

        protected string _title = null!;
        public string title
        {
            get { return _title; }
        }

        protected ListPage<Person> _list = null!;
        public ListPage<Person> list
        {
            get { return _list; }
        }

        protected ListPage<Person> _list_selected = null!;
        public ListPage<Person> list_selected
        {
            get { return _list_selected; }
        }
        protected Form<Person> _editor = null!;
        public Form<Person> editor
        {
            get { return _editor; }
        }

        public void Show()
        {
            // Preview list interface
            this._list.AddColumn("Id", "id");
            this._list.AddColumn("Name", "fullName");
            this._list.AddColumn("Phone", "phone");
            this._list.AddColumn("Email", "email");

            // Selected element interface
            this._list_selected.AddColumn("Name", "fullName");
            this._list_selected.AddColumn("Address", "address");
            this._list_selected.AddColumn("Last purchase", "lastPurchase");
            
            // Editor interface
            this._editor.TextBox("Fistname", "firstName");
            this._editor.TextBox("Lastname", "lastName");
            this._editor.TextBox("Road", "addressRoadName");
            this._editor.TextBox("Door number", "addressDoorNumber");
            this._editor.TextBox("Zipcode", "addressZipCode");
            this._editor.TextBox("City", "addressCity");
            this._editor.IntBox("Phone", "phone");
            this._editor.TextBox("Email", "email");

            Screen.Display(this._intrface);

            this._intrface.Edit();
        } 

    }
}