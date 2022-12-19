using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Week_3_BankApp.Utilities;

namespace Week_3_BankApp.Model
{
    public class Account
    {
        private string accountName;
        private AccountType accountType;
        private string accountNumber;
        private decimal balance;
        private Customer customer;
        public List<Statements> Statements;
        public string firstName;
        private string lastName;
        private AccountType savings;

        public Account(string accountName, AccountType accountType, string accountNumber, decimal balance, Customer customer)
        {
            this.accountName = accountName;
            this.accountType = accountType;
            this.accountNumber = AccountGenerator.Account_Generator(); ;
            this.balance = balance;
            this.customer = customer;
            Statements = new List<Statements>();

        }




        public Account()
        {

        }

        public Account(string firstName, string lastName, AccountType savings)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.savings = savings;
        }

        public string AccountName { get => accountName; set => accountName = value; }
        public AccountType AccountType { get => accountType; set => accountType = value; }
        public string AccountNumber { get => accountNumber; set => accountNumber = value; }
        public decimal Balance { get => balance; set => balance = value; }
        public Customer Customer { get => customer; set => customer = value; }


        public void Deposit(decimal amount)
        {

            if (amount < 0)
            {
                Console.WriteLine("Invalid amount range");
            }
            else
            {
                balance += amount;
                Statements.Add(new Statements()
                {
                    Tdate = DateTime.Now,
                    description = "deposit",
                    amount = amount,
                    AccountBalance = balance
                });
                Console.WriteLine("Deposit Successful");
            }

        }

        public void Withdraw(decimal amount)
        {
            if (amount < 0)
            {
                Console.WriteLine("Invalid amount range");
            }
            else if (amount > balance)
            {
                Console.WriteLine("Insufficient funds");
            }
            else if (AccountType == AccountType.Savings && balance - 1000 < 1000)
            {
                Console.WriteLine("Cannot withdraw less than 1000");
            }
            else
            {
                balance -= amount;
                Statements.Add(new Statements()
                {
                    Tdate = DateTime.Now,
                    description = "Withdraw",
                    amount = amount,
                    AccountBalance = balance
                });
                Console.WriteLine("Withdrawal Successful");
            }
        }

        public void Balancee()
        {
            Console.WriteLine($"Your balance is {balance}");
        }

        public void TransferMoney(Account account, Account account2, decimal amount)
        {
            if (amount < 0)
            {
                Console.WriteLine("Invalid amount range");
            }
            else if (amount > account.balance)
            {
                Console.WriteLine("insufficient funds");
            }
            else if (account.AccountType == AccountType.Savings && account.balance == 1000)
            {
                Console.WriteLine("Cannot withdraw less than 1000");
            }
            else
            {
                account.balance -= amount;
                account.Statements.Add(new Statements()
                {
                    Tdate = DateTime.Now,
                    description = "Debited",
                    amount = amount,
                    AccountBalance = balance
                });
                account2.balance += amount;
                account2.Statements.Add(new Statements()
                {
                    Tdate = DateTime.Now,
                    description = "Credited",
                    amount = amount,
                    AccountBalance = account2.balance
                });
            }

        }


        public class Transfer_Money
        {

            public void TransferMoney(Account account, Account account2, decimal amount)
            {
                if (amount < 0)
                {
                    Console.WriteLine("Invalid amount range");
                }
                else if (amount > account.balance)
                {
                    Console.WriteLine("insufficient funds");
                }
                else if (account.AccountType == AccountType.Savings && account.balance == 1000)
                {
                    Console.WriteLine("Cannot withdraw less than 1000");
                }
                else
                {
                    account.balance -= amount;
                    account2.balance += amount;
                }

            }
        }
    }
}
