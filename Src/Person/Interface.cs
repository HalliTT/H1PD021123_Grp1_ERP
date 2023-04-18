using TECHCOOL.UI;

namespace App
{
    public class PersonInterface
    {
        public PersonInterface(string title, ListPage<Person> list)
        {
            _title = title;
            _list = list;
            _list_selected = new ListPage<Person> {};
            _editor = new Form<Person> {};

            _intrface = new Interface<Person> (_title, 
                                               _list, 
                                               _list_selected, 
                                               _editor);
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

        public Screen Show()
        {
            // Preview list interface
            _list.AddColumn("Id", "id");
            _list.AddColumn("Name", "fullName");
            _list.AddColumn("Phone", "phone");
            _list.AddColumn("Email", "email");

            // Selected element interface
            _list_selected.AddColumn("Name", "fullName");
            _list_selected.AddColumn("Address", "addressAsStr");
            _list_selected.AddColumn("Last purchase", "lastPurchase");
            
            // Editor interface
            _editor.TextBox("Fistname", "firstName");
            _editor.TextBox("Lastname", "lastName");
            _editor.TextBox("Road", "addressRoadName");
            _editor.TextBox("Door number", "addressDoorNumber");
            _editor.TextBox("Zipcode", "addressZipCode");
            _editor.TextBox("City", "addressCity");
            _editor.IntBox("Phone", "phone");
            _editor.TextBox("Email", "email");

            return _intrface;
        } 
    }
}