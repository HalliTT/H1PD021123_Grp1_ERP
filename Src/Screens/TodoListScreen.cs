using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TECHCOOL.UI;

namespace H1PD021123_Grp1_ERP.Screens
{
    public class TodoListScreen : Screen
    {
        public override string Title { get; set; } = "List of tasts to do";
        protected override void Draw()
        {
            Clear(this);
            ListPage<Todo> list = new ListPage<Todo>();
            list.Add(new Todo("buy milk"));
            list.Add(new Todo("buy bread"));
            list.Add(new Todo("buy snus"));

            list.AddColumn("Todo", "Title");
            list.AddColumn("State", "State");
            list.AddColumn("Priority", "Priority");

            
            Todo selected = list.Select();
            Console.WriteLine("You selected: " + selected.Title);
        }
    }
}
