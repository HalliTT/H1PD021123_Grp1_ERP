using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1PD021123_Grp1_ERP.Screens
{
    public class Todo
    {
        public enum TodoState { Todo, Started, Done }
        public string Title { get; set; } = "";
        public int Priority { get; set; }
        public TodoState State { get; set;}
        public Todo(string title, int priority=1)
        {
            Title = title;
            Priority = priority;
            
        }
    }
}
