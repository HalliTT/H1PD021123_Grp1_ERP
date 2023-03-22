using System;
using TECHCOOL.UI;

namespace App
{    
    public class TestScreen : Screen
    {
        public override string Title { get; set; } = "List of tasks to do"; 
        protected override void Draw()
        {    
            Clear(this); //Clean the screen
            
            ListPage<string> listPage = new ListPage<string>();
            listPage.Add("Buy milk");
            listPage.Add("Walk the dog");

            listPage.AddColumn("Todo", "Title"); //Add column to the list

            listPage.Draw(); //Draw the screen
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Screen.Display( new TestScreen() );
        }
    }
}