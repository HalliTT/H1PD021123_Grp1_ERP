using TECHCOOL.UI;

namespace App
{
    //Understanding the original programmer's intent is the most difficult problem.
    //- Fjelstad & Hamlen 1979
    public class MenuInterface : Screen
    {
        public override string Title { get; set; } = "Menu";

        public MenuInterface(Screen[] screens)
        {
            _menu = new Menu();

            foreach (var screen in screens)
                _menu.Add(screen);
        }

        protected Menu _menu;

        protected override void Draw()
        {
            Console.Clear();
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
            Console.Clear();


            _list.AddKey(ConsoleKey.F1, Create);
            _list.AddKey(ConsoleKey.F2, Edit);
            _list.AddKey(ConsoleKey.F5, Delete);
            _list.AddKey(ConsoleKey.F3, What);


            _selected = _list.Select();

            if (_selected != null)
            {
                Console.Clear();

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

            if (obj != null)
            {
                _editor.Edit(obj);

                if (typeof(T) == typeof(Company))
                {
                    _db.InsertCompany((Company)(object)obj);
                }
                else if (typeof(T) == typeof(Person))
                {
                    _db.InsertPerson((Person)(object)obj);
                }
                else if (typeof(T) == typeof(Product))
                {
                    _db.InsertProduct((Product)(object)obj);
                }
                else if (typeof(T) == typeof(Sales))
                {
                    _db.InsertOrder((Sales)(object)obj);
                }
                else
                {
                    return;
                }

                _list.Add(obj);
            }
        }

        private void Edit(T obj)
        {
            Console.Clear();

            if (_selected != null)
            {
                _list.Remove(_selected);

                _editor.Edit(_selected);

                if (typeof(T) == typeof(Company))
                {
                    _db.UpdateCompany((Company)(object)_selected);
                }
                else if (typeof(T) == typeof(Person))
                {
                    _db.UpdatePerson((Person)(object)_selected);
                }
                else if (typeof(T) == typeof(Product))
                {
                    _db.UpdateProduct((Product)(object)_selected);
                }
                else if (typeof(T) == typeof(Sales))
                {
                    _db.UpdateOrder((Sales)(object)_selected);
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
                    _db.DeleteCompany((Company)(object)_selected);
                }
                else if (typeof(T) == typeof(Person))
                {
                    _db.DeletePerson((Person)(object)_selected);
                }
                else if (typeof(T) == typeof(Product))
                {
                    _db.DeleteProduct((Product)(object)_selected);
                }
                else if (typeof(T) == typeof(Sales))
                {
                    _db.DeleteOrder((Sales)(object)_selected);
                }
                else
                {
                    return;
                }

                _list.Remove(_selected);
            }
        }

        private void What(T obj)
        {
            Console.Clear();

            int angle = 0;

            while (!Console.KeyAvailable)
            {
                Console.Clear();

                int x = (int)(Math.Cos(angle * Math.PI / 180) * 10) + 30;
                int y = (int)(Math.Sin(angle * Math.PI / 180) * 4) + 8;

                Console.SetCursorPosition(x, y);

                Console.WriteLine("         /\\_/\\");
                Console.SetCursorPosition(x, y + 1);
                Console.WriteLine("        ( o o )");
                Console.SetCursorPosition(x, y + 2);
                Console.WriteLine("      C('')('')");

                angle = (angle + 10) % 360;

                System.Threading.Thread.Sleep(100);
            }

            //     int left = 10;
            //     int top = 10;
            //     int jumpHeight = 4;
            //     int frame = 0;

            //     while (!Console.KeyAvailable)
            //     {
            //         Console.SetCursorPosition(left, top);

            //         if (frame % (jumpHeight * 2) < jumpHeight)
            //         {
            //             Console.Write(" /\\ ");
            //             Console.SetCursorPosition(left, top + 1);
            //             Console.Write("(oo)");
            //             Console.SetCursorPosition(left, top + 2);
            //             Console.Write(" II ");
            //         }
            //         else
            //         {
            //             Console.Write("    ");
            //             Console.SetCursorPosition(left, top + 1);
            //             Console.Write("    ");
            //             Console.SetCursorPosition(left, top + 2);
            //             Console.Write("    ");
            //         }

            //         System.Threading.Thread.Sleep(100);

            //         Console.SetCursorPosition(left, top);

            //         if (frame % (jumpHeight * 2) < jumpHeight)
            //         {
            //             Console.Write("    ");
            //             Console.SetCursorPosition(left, top + 1);
            //             Console.Write("    ");
            //             Console.SetCursorPosition(left, top + 2);
            //             Console.Write("    ");
            //         }
            //         else
            //         {
            //             Console.Write(" \\/ ");
            //             Console.SetCursorPosition(left, top + 1);
            //             Console.Write("(oo)");
            //             Console.SetCursorPosition(left, top + 2);
            //             Console.Write(" II ");
            //         }

            //         System.Threading.Thread.Sleep(100);

            //         left++;

            //         if (left > Console.BufferWidth - 10)
            //         {
            //             left = 10;
            //         }

            //         frame++;
            //     }
        }
    }
}