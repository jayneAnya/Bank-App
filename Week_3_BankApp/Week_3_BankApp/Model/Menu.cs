using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Week_3_BankApp.Service.Implementation;
using Week_3_BankApp.Utilities;
using static Week_3_BankApp.Utilities.AccountTables;

namespace Week_3_BankApp.Model
{
    public class Menu
    {
        Customer customer = new Customer();

        public static void MenuMethod(Customer customer)
        {
            Console.Clear();
            Console.WriteLine("********************************************************************************************************************");
            Console.WriteLine($"Hello {customer.FirstName}, Welcome to DevJayne Bank");
            Console.WriteLine("Choose an operation:");
            Console.WriteLine("0: Add Account\n any other number to see other transactions");
            var Opt = Console.ReadLine();
            int opt;
            while (!int.TryParse(Opt, out opt))
            {
                Console.WriteLine("Invalid data type! Input the valid number: ");
                Opt = Console.ReadLine();
            }
            if (opt == 0)
            {
                RegisterServiceImpl.CreateAccount(customer);
                MenuMethod(customer);
            }
            Console.WriteLine("1: Deposit Money\n2: Withdraw Money\n3: Check Balance\n4: Transfer Money\n5: Print Account Details\n6: Print Statement of Account\n7: Logout");
            string AccOption = Console.ReadLine();

            bool run = Validation.Validate(AccOption);
            while (run)
            {
                Console.WriteLine("Input correct option");
                AccOption = Console.ReadLine();
            }


            if (AccOption == "1")
            {
                Console.WriteLine("Enter the amount you wish to deposit");
                var Amount = Console.ReadLine();
                decimal amount;

                while (!decimal.TryParse(Amount, out amount))
                {
                    Console.WriteLine("Invalid Input! Input correct value: ");
                    Amount = Console.ReadLine();
                }
                Account account = GetAccount(customer);
                deposit(amount, account);
                Console.WriteLine("Will you like to perform any other transaction");
                Console.WriteLine("1: Yes\n2: No");
                string answer = Console.ReadLine();
                bool condition = Validation.Validate(answer);
                while (condition)
                {
                    Console.WriteLine("Input correct option");
                    answer = Console.ReadLine();
                }

                if (answer == "1")
                {
                    MenuMethod(customer);
                }
                else if (answer == "2")
                {
                    Console.Clear();
                    Main_Menu.MainMenu();
                }
            }
            else if (AccOption == "2")
            {
                Console.WriteLine("Enter the amount you wish to withdraw");
                var Amount = Console.ReadLine();
                decimal amount;

                while (!decimal.TryParse(Amount, out amount))
                {
                    Console.WriteLine("Invalid Input! Input correct value: ");
                    Amount = Console.ReadLine();
                }
                Account account = GetAccount(customer);
                withdraw(amount, account);
                Console.WriteLine("Will you like to perform any other transaction");
                Console.WriteLine("1: Yes\n2: No");
                string answer = Console.ReadLine();
                bool condition = Validation.Validate(answer);
                while (condition)
                {
                    Console.WriteLine("Input correct option");
                    answer = Console.ReadLine();
                }

                if (answer == "1")
                {
                    MenuMethod(customer);
                }
                else if (answer == "2")
                {
                    Console.Clear();
                    Main_Menu.MainMenu();
                }
            }
            else if (AccOption == "3")
            {
                Account account = GetAccount(customer);
                balance(account);
                Console.WriteLine("Will you like to perform any other transaction");
                Console.WriteLine("1: Yes\n2: No");
                string answer = Console.ReadLine();
                bool condition = Validation.Validate(answer);
                while (condition)
                {
                    Console.WriteLine("Input correct option");
                    answer = Console.ReadLine();
                }

                if (answer == "1")
                {
                    MenuMethod(customer);
                }
                else if (answer == "2")
                {
                    Console.Clear();
                    Main_Menu.MainMenu();
                }
            }
            else if (AccOption == "4")
            {
                Console.WriteLine("How much do you want to transfer? ");
                var _amount = Console.ReadLine();
                decimal _Amount;

                while (!decimal.TryParse(_amount, out _Amount) || decimal.Parse(_amount) < 0)
                {
                    Console.WriteLine("Invalid Input! Input correct value: ");
                    _amount = Console.ReadLine();
                }
                Account account = GetAccount(customer);
                Console.WriteLine("Which Account number do you wish to transfer to?");
                string AccNum = Console.ReadLine();
                Account destination = RegisterServiceImpl.GetAccount(RegisterUser.customerList, AccNum);
                if (destination.firstName != null)
                {
                    Transfer(account, destination, _Amount);
                }
                else
                {
                    Console.WriteLine("You have entered an invalid account number");

                }
                Console.WriteLine("Will you like to perform any other transaction");
                Console.WriteLine("1: Yes\n2: No");
                string answer = Console.ReadLine();
                bool condition = Validation.Validate(answer);
                while (condition)
                {
                    Console.WriteLine("Input correct option");
                    answer = Console.ReadLine();
                }

                if (answer == "1")
                {

                    MenuMethod(customer);
                }
                else if (answer == "2")
                {
                    Console.Clear();
                    Main_Menu.MainMenu();
                }



            }
            else if (AccOption == "5")
            {
                Account_Tables.AccountDetails(customer);
                Console.WriteLine("Will you like to perform any other transaction");
                Console.WriteLine("1: Yes\n2: No");
                string answer = Console.ReadLine();
                bool condition = Validation.Validate(answer);
                while (condition)
                {
                    Console.WriteLine("Input correct option");
                    answer = Console.ReadLine();
                }

                if (answer == "1")
                {

                    MenuMethod(customer);
                }
                else if (answer == "2")
                {
                    Console.Clear();
                    Main_Menu.MainMenu();
                }
            }
            else if (AccOption == "6")
            {
                Account account = GetAccount(customer);
                Account_Tables.PrintStatement(account);
                Console.WriteLine("Will you like to perform any other transaction");
                Console.WriteLine("1: Yes\n2: No");
                string answer = Console.ReadLine();
                bool condition = Validation.Validate(answer);
                while (condition)
                {
                    Console.WriteLine("Input correct option");
                    answer = Console.ReadLine();
                }

                if (answer == "1")
                {
                    MenuMethod(customer);
                }
                else if (answer == "2")
                {
                    Console.Clear();
                    Main_Menu.MainMenu();
                }
            }
            else if (AccOption == "7")
            {
                Console.Clear();
                Main_Menu.MainMenu();
            }

        }


        public static void deposit(decimal amount, Account account)
        {
            account.Deposit(amount);
        }

        public static void withdraw(decimal amount, Account account)
        {
            account.Withdraw(amount);
        }

        public static void balance(Account account)
        {
            account.Balancee();
        }

        public static void Transfer(Account senderAccount, Account recieverAccount, decimal amount)
        {
            senderAccount.TransferMoney(senderAccount, recieverAccount, amount);
        }


        public static Account GetAccount(Customer customer)
        {
            Console.WriteLine("Which account do you want to use for this operations? ");
            int count = customer.Accounts.Count;
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"{i + 1} {customer.Accounts[i].AccountName} {customer.Accounts[i].AccountNumber}");
            }
            Console.WriteLine("Choose your preferred account: ");
            var _option = Console.ReadLine();
            while (int.Parse(_option) < 0 || int.Parse(_option) > count)
            {
                Console.WriteLine("Invalid option");
                Console.WriteLine("Choose your preferred account: ");
                _option = Console.ReadLine();
            }
            int accountOption = int.Parse(_option);
            return customer.Accounts[accountOption - 1];
        }

    }
}



