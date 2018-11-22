using DAL.Interface.DTO;
using DAL.Interface.Interfaces;
using System;
using System.Collections.Generic;

namespace DAL.Repositories
{
    /// <summary>
    /// Provides methods for interaction with the accounts binary repository
    /// </summary>
    public class AccountBinaryRepository : IRepository
    {
        public void CloseAccount(string accountNumber)
        {
            throw new NotImplementedException();
        }

        public void DepositAccount(string accountNumber, decimal amount)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Account> GetAccounts()
        {
            throw new NotImplementedException();
        }

        public void OpenAccount(Account account)
        {
            throw new NotImplementedException();
        }

        public void WithdrawAccount(string accountNumber, decimal amount)
        {
            throw new NotImplementedException();
        }
    }
}
