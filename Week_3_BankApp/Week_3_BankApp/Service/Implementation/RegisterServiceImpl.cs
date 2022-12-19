using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Week_3_BankApp.Model;
using Week_3_BankApp.Utilities;

namespace Week_3_BankApp.Service.Implementation
{
    public class RegisterServiceImpl /*: IRegisterService*/
    {


        public static void CreateAccount(Customer newCustomer)
        {
            Console.WriteLine("Chooose your preferred account type");
            Console.WriteLine("1: Savings Account\n2: Current Account");
            string Option = Console.ReadLine();
            bool correct = Validation.Validate(Option);
            while (correct)
            {
                Console.WriteLine("Input correct option");
                Option = Console.ReadLine();
            }

            if (Option == "1")
            {
                Account Repository = new Account(newCustomer.FirstName, newCustomer.LastName, AccountType.Savings);
                newCustomer.Accounts.Add(Repository);
            }
            else if (Option == "2")
            {
                Account repository = new Account(newCustomer.FirstName, newCustomer.LastName, AccountType.Current);
                newCustomer.Accounts.Add(repository);
            }


        }

        public static Account GetAccount(List<Customer> Customers, string AccountNumber)
        {
            for (int i = 0; i < Customers.Count; i++)
            {
                for (int j = 0; j < Customers[i].Accounts.Count; j++)
                {
                    if (Customers[i].Accounts[j].AccountNumber == AccountNumber)
                    {
                        return Customers[i].Accounts[j];
                    }
                }
            }
            return new Account();
        }


    }
}






