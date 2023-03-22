﻿using H1PD021123_Grp1_ERP.Customer;
using System;
using TECHCOOL;
using TECHCOOL.UI;
using H1PD021123_Grp1_ERP.Screens;

namespace App
{
    internal class Program
    {
        static void Main(string[] args)
        {      
            MyFirstScreen firstScreen = new MyFirstScreen();
            TodoListScreen todo = new TodoListScreen();
            CustomerListScreen customerList = new CustomerListScreen();
            Screen.Display(customerList);
        }
    }
}