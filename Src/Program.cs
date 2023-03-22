using System;
using TECHCOOL;
using TECHCOOL.UI;
namespace App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var fullScreen = new CompanyFullListScreen();
            Screen.Display(fullScreen);

            var shortScreen = new CompanyShortListScreen();
            Screen.Display(shortScreen);
        }
    }
}