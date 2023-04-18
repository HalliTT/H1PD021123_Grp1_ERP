using TECHCOOL.UI;

namespace App
{
    public class MenuInterface : Screen
    {
        public override string Title { get; set; } = "Menu"; 

        public MenuInterface(Screen[] screens)
        {
            _company = company;
            _person = person;
            _product = product;
            _sales = sales;

            _menu = new Menu();

            foreach (var screen in screens)
                _menu.Add(screen);
        }

        protected Menu _menu;

        protected Screen _company;
        public Screen company
        {
            get { return _company; }
        }

        protected Screen _person;
        public Screen person
        {
            get { return _person; }
        }

        protected Screen _product;
        public Screen product
        {
            get { return _product; }
        }

        protected Screen _sales;
        public Screen sales
        {
            get { return _sales; }
        }

        protected override void Draw()
        {
            _menu.Start(this);
        }
    }

    public class Interface<T> : Screen
    {
        public Interface(string title,
                         ListPage<T> list, 
                         ListPage<T> list_selected,
                         Form<T> editor)
        {
            Title = title;
            _list = list;
            _list_selected = list_selected;
            _editor = editor;

            _db = new Database();
        }
        public override string Title { get; set; }

        protected ListPage<T> _list = null!;
        public ListPage<T> list
        {
            get { return _list; }
        }

        protected ListPage<T> _list_selected = null!;
        public ListPage<T> list_selected
        {
            get { return _list_selected; }
        }

        protected Form<T> _editor;
        public Form<T> editor
        {
            get { return _editor; }
        }

        protected T? _selected;
        public T? selected
        {
            get { return _selected; }
        }

        protected Database _db;
        public Database db
        {
            get { return _db; }
        }

        protected override void Draw()
        {
            Clear(this);

            _list.AddKey(ConsoleKey.F1, Create);
            _list.AddKey(ConsoleKey.F2, Edit);
            _list.AddKey(ConsoleKey.F5, Delete);

            _selected = _list.Select();

            if (_selected != null)
            {
                Clear(this);

                _list_selected.Add(_selected);
                _list_selected.Draw();

                _list_selected.Remove(_selected);
            }
            else
            {
                Quit();
                return;
            }
        }

        private void Create(T obj)
        {
            Console.Clear();

            if (_selected != null)
            {
                _editor.Edit(_selected);

                if (typeof(T) == typeof(Company))
                {
                    _db.InsertCompany((Company)(object) _selected);
                }
                else if (typeof(T) == typeof(Person))
                {
                    _db.InsertPerson((Person)(object) _selected);
                }
                else if (typeof(T) == typeof(Product))
                {
                    _db.InsertProduct((Product)(object) _selected);
                }
                else if (typeof(T) == typeof(Sales))
                {
                    _db.InsertOrder((Sales)(object) _selected);
                }
                else
                {
                    return;
                }

                _list.Add(_selected);
            }
        }

        private void Edit(T obj)
        {
            Console.Clear();

            if (_selected != null)
            {
                _editor.Edit(_selected);

                if (typeof(T) == typeof(Company))
                {
                    _db.UpdateCompany((Company)(object) _selected);
                }
                else if (typeof(T) == typeof(Person))
                {
                    _db.UpdatePerson((Person)(object) _selected);
                }
                else if (typeof(T) == typeof(Product))
                {
                    _db.UpdateProduct((Product)(object) _selected);
                }
                else if (typeof(T) == typeof(Sales))
                {
                    _db.UpdateOrder((Sales)(object) _selected);
                }
                else
                {
                    return;
                }

                _list.Add(_selected);
            }
        }

        private void Delete(T obj)
        {
            Console.Clear();
            
            if (_selected != null)
            {
                if (typeof(T) == typeof(Company))
                {
                    _db.DeleteCompany((Company)(object) _selected);
                }
                else if (typeof(T) == typeof(Person))
                {
                    _db.DeletePerson((Person)(object) _selected);
                }
                else if (typeof(T) == typeof(Product))
                {
                    _db.DeleteProduct((Product)(object) _selected);
                }
                else if (typeof(T) == typeof(Sales))
                {
                    _db.DeleteOrder((Sales)(object) _selected);
                }
                else
                {
                    return;
                }

                _list.Remove(_selected);
            }
        }
    }
}