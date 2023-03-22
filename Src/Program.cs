using System;
using TECHCOOL;
using TECHCOOL.UI;
namespace App
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var shortScreen = new CompanyShortListScreen();
            Screen.Display(shortScreen);

            var fullScreen = new CompanyFullListScreen();
            Screen.Display(fullScreen);


        }
    }
}