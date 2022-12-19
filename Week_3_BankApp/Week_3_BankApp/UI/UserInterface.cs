using Week_3_BankApp.Service.Implementation;
using System;
using System.Collections.Generic;
using System.Text;
using Week_3_BankApp.Model;

namespace Week_3_BankApp.UI
{
    internal class UserInterface
    {
        public static void UI()
        {
            Console.WriteLine("Welcome to DevJayne bank");
            Console.WriteLine("Choose an operation");
            Main_Menu.MainMenu();
            var RegisterServiceImpl = new RegisterServiceImpl();
        }
    }
}
