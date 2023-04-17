using TECHCOOL.UI;

namespace App
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var list = new ListPage<Sales> { };

            var obj = new Sales(DateTime.Now.ToString(), DateTime.Now.ToString(), 2, State.Created, 2000);
            list.Add(obj);

            var screen = new SalesInterface("Sales list", list);
            screen.Show();
        }
    }
}