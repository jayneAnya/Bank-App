using System;
using System.Collections.Generic;
using System.Text;
using Week_3_BankApp.Model;

namespace Week_3_BankApp.Service
{
    public interface IRegisterService
    {
          void CreateAccount(Customer newCustomer);

    }
}
