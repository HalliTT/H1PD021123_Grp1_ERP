using TECHCOOL.UI;

namespace App
{
    public class SetupSalesInterface
    {
        public SetupSalesInterface(string title, ListPage<Sales> list)
        {
            _title = title;
            _list = list;
            _list_selected = new ListPage<Sales> {};
            _editor = new Form<Sales> {};

            _intrface = new Interface<Sales> (_title, 
                                                   _list, 
                                                   _list_selected, 
                                                   _editor);
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
            _list.AddColumn("Id", "id");
            _list.AddColumn("Creation", "creationTimestamp");
            _list.AddColumn("Customer Id", "customerId");
            _list.AddColumn("Name", "fullName");
            _list.AddColumn("Total", "totalOrderPrice");

            // Selected element interface
            _list_selected.AddColumn("Id", "id");
            _list_selected.AddColumn("Date", "creationTimestamp");
            _list_selected.AddColumn("Customer Id", "customerId");
            _list_selected.AddColumn("Name", "fullName");
            
            // Editor interface
            _editor.SelectBox("Customer", "customerId");
            
            var db = new Database();
            int i = 0;
            
            foreach (var customer in db.GetPerson())
            {
                _editor.AddOption("Customer", customer.fullName + " - " + customer.id.ToString(), $"{customer.id}");
                i++;
            }
  
            return _intrface;
        } 
    }
}