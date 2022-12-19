using System;
using System.Collections.Generic;
using System.Text;
using Week_3_BankApp.Model;

namespace Week_3_BankApp.Utilities
{
    public class AccountTables
    {
        public static class Account_Tables
        {
            public static void AccountDetails(Customer customer)
            {
                Console.WriteLine("ACCOUNT DETAILS");
                Console.WriteLine("--------------------------------------------------------------------------------------------");
                Console.WriteLine("|{0,20} | {1,20} | {2,20} | {3,20} | ", "FULL NAME", "ACCOUNT NUMBER", "ACCOUNT TYPE", "AMOUNT BALANCE");
                Console.WriteLine("--------------------------------------------------------------------------------------------");

                foreach (var account in customer.Accounts)
                {
                    Console.WriteLine("|{0,20} | {1,20} | {2,20} | {3,20} | ", account.AccountName, account.AccountNumber, account.AccountType, account.Balance);
                }


            }

            public static void PrintStatement(Account account)
            {
                Console.WriteLine("ACCOUNT DETAILS");
                Console.WriteLine("--------------------------------------------------------------------------------------------");
                Console.WriteLine("|{0,20} | {1,20} | {2,20} | {3,20} | ", "DATE", "DESCRIPTION", "AMOUNT", "BALANCE");
                Console.WriteLine("--------------------------------------------------------------------------------------------");
                int index = 0;
                foreach (var statement in account.Statements)
                {
                    Console.WriteLine("|{0,20} | {1,20} | {2,20} | {3,20} | ", account.Statements[index].Tdate, account.Statements[index].description, account.Statements[index].amount, account.Statements[index].AccountBalance);
                    index++;
                    Console.WriteLine("--------------------------------------------------------------------------------------------");
                }
            }
        }
    }
}
