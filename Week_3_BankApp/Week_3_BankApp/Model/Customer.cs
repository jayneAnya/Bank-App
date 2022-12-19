using Week_3_BankApp.Utilities;
using Week_3_BankApp.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Week_3_BankApp.Model
{
    public class Customer
    {

        private string firstName;
        private string lastName;
        private string accountName;
        private string email;
        private string phoneNumber;
        private string city;
        private string country;
        private int age;
        private string password;
        private Account customerAccount;
        private AccountType accountType;
        private string FullName;
        public List<Account> Accounts = new List<Account>();

        public Customer(string firstName, string lastName, string email, string phoneNumber, int age, Account customerAccount, AccountType accountType, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            AccountName = $"{FirstName} {LastName}";
            Email = email;
            PhoneNumber = phoneNumber;
            Age = age;
            AccountType = accountType;
            Password = password;
            FullName = $"{FirstName} {LastName}";
            Accounts.Add(customerAccount);
        }

        public Customer()
        {

        }

        public Customer(string firstName, string lastName, string email, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
        }

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Email { get => email; set => email = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string City { get => city; set => city = value; }
        public string Country { get => country; set => country = value; }
        public int Age { get => age; set => age = value; }
        public string Password { get => password; set => password = value; }
        public Account CustomerAccount { get => customerAccount; set => customerAccount = value; }
        public string AccountName { get => accountName; set => accountName = value; }
        public AccountType AccountType { get => accountType; set => accountType = value; }
        public string FullName1 { get => FullName; set => FullName = value; }
    }
}
