using DAL.Interface.DTO;
using DAL.Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Fake.Repositories
{
    public class FakeRepository : IRepository
    {
        private List<Account> _accounts = new List<Account>();

        public void CloseAccount(string accountNumber)
        {
            Account account = GetAccount(accountNumber);
            _accounts.Remove(account);
        }

        public void DepositAccount(string accountNumber, decimal amount)
        {
            Account account = GetAccount(accountNumber);
            account.Deposit(amount);
        }

        public IEnumerable<Account> GetAccounts()
        {
            return new List<Account>(_accounts);
        }

        public void OpenAccount(Account account)
        {
            if (_accounts.Find(acc => acc.AccountNumber == account.AccountNumber) == null)
            {
                _accounts.Add(account);
            }
            else
            {
                throw new ArgumentException($"Account with number {account.AccountNumber} is already exsist");
            }
        }

        public void WithdrawAccount(string accountNumber, decimal amount)
        {
            Account account = GetAccount(accountNumber);
            account.Withdraw(amount);
        }

        private Account GetAccount(string accountNumber)
        {
            var account = _accounts.Where((acc) => acc.AccountNumber == accountNumber).First();
            if (account == null)
            {
                throw new ArgumentException($"Account with number {accountNumber} doesn't exists");
            }
            return account;
        }
    }
}
