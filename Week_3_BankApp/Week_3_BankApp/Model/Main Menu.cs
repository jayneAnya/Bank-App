using Week_3_BankApp.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Week_3_BankApp.Service.Implementation;
using Week_3_BankApp.Utilities;

namespace Week_3_BankApp.Model
{
    public class Main_Menu : RegisterServiceImpl
    {
        public static void MainMenu()
        {
            RegisterServiceImpl login = new RegisterServiceImpl();
            Console.WriteLine("***************************");
            Console.WriteLine("1: Login\n2: Open new User account\n3: Exit App");
            Console.WriteLine("***************************");
            string Option = Console.ReadLine();
            bool correct = Validation.Validate(Option);
            while (correct)
            {
                Console.WriteLine("Input correct option");
                Option = Console.ReadLine();
            }

            if (Option == "1")
            {
                Console.WriteLine("Enter password");
                string password = Console.ReadLine();
                Console.WriteLine("Enter email");
                string email = Console.ReadLine();
                Customer customer = new Customer();
                for (int i = 0; i < RegisterUser.customerList.Count; i++)
                {
                    if (RegisterUser.customerList[i].Password == password && RegisterUser.customerList[i].Email == email)
                    {
                        customer = RegisterUser.customerList[i];
                        break;
                    }

                }

                if (customer.Accounts.Count != 0)
                {
                    Menu.MenuMethod(customer);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("User account not in Database");
                    MainMenu();
                }



            }
            else if (Option == "2")
            {
                RegisterUser.registerCustomer();
            }
            else if (Option == "3")
            {
                Environment.Exit(0);
            }
        }
    }
}
