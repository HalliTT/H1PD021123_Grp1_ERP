using TECHCOOL.UI;

namespace App
{
    public class MenuInterface : Screen
    {
        public override string Title { get; set; } = "Menu"; 

        public MenuInterface(Screen company, Screen person, Screen product, Screen sales)
        {
            this._company = company;
            this._person = person;
            this._product = product;
            this._sales = sales;

            this.menu = new Menu();
            this.menu.Add(company);
            this.menu.Add(person);
            this.menu.Add(product);
            this.menu.Add(sales);
        }

        protected Menu menu;

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
            menu.Start(this);
        }
    }

    public class Interface<T> : Screen where T : class 
    {
        public Interface(string title,
                         ListPage<T> list, 
                         ListPage<T> list_selected,
                         Form<T> editor)
        {
            this.Title = title;
            this._list = list;
            this._list_selected = list_selected;
            this._editor = editor;

            this._db = new Database();
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

        protected T _selected;
        public T selected
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

            this._list.AddKey(ConsoleKey.F1, Create);
            this._list.AddKey(ConsoleKey.F2, Edit);
            this._list.AddKey(ConsoleKey.F5, Delete);

            this._selected = this._list.Select();

            if (this._selected != null)
            {
                Clear(this);

                this._list_selected.Add(this._selected);
                this._list_selected.Draw();

                this._list_selected.Remove(this._selected);
            }
            else
            {
                Quit();
                return;
            }
        }

        public void Create(T obj)
        {
            Console.Clear();

            this._editor.Edit(this._selected);

            if (typeof(T) == typeof(Company))
            {
                this._db.InsertCompany((Company)(object) this._selected);
            }
            else if (typeof(T) == typeof(Person))
            {
                this._db.InsertPerson((Person)(object) this._selected);
            }
            else if (typeof(T) == typeof(Product))
            {
                this._db.InsertProduct((Product)(object) this._selected);
            }
            else if (typeof(T) == typeof(Sales))
            {
                this._db.InsertOrder((Sales)(object) this._selected);
            }
            else
            {
                return;
            }

            this._list.Add(this._selected);
        }

        public void Edit(T obj)
        {
            Console.Clear();

            this._editor.Edit(this._selected);

            if (typeof(T) == typeof(Company))
            {
                this._db.UpdateCompany((Company)(object) this._selected);
            }
            else if (typeof(T) == typeof(Person))
            {
                this._db.UpdatePerson((Person)(object) this._selected);
            }
            else if (typeof(T) == typeof(Product))
            {
                this._db.UpdateProduct((Product)(object) this._selected);
            }
            else if (typeof(T) == typeof(Sales))
            {
                this._db.UpdateOrder((Sales)(object) this._selected);
            }
            else
            {
                return;
            }

            this._list.Add(this._selected);
        }

        public void Delete(T obj)
        {
            Console.Clear();
            
            if (typeof(T) == typeof(Company))
            {
                this._db.DeleteCompany((Company)(object) this._selected);
            }
            else if (typeof(T) == typeof(Person))
            {
                this._db.DeletePerson((Person)(object) this._selected);
            }
            else if (typeof(T) == typeof(Product))
            {
                this._db.DeleteProduct((Product)(object) this._selected);
            }
            else if (typeof(T) == typeof(Sales))
            {
                this._db.DeleteOrder((Sales)(object) this._selected);
            }
            else
            {
                return;
            }

            this._list.Remove(this._selected);
        }
    }
}