using System;
using TECHCOOL;
using TECHCOOL.UI;
namespace App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            var shortScreen = new CompanyShortListScreen();
            Screen.Display(shortScreen);
        }
    }
}