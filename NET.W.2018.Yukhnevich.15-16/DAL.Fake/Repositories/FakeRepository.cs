using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;

namespace DAL.Fake.Repositories
{
    /// <summary>
    /// Provides methods for interact with some fake repository of the accounts
    /// </summary>
    public class FakeRepository : IRepository
    {
        /// <summary>
        /// The accounts list
        /// </summary>
        private List<Account> _accounts = new List<Account>();

        /// <summary>
        /// Closes the account
        /// </summary>
        /// <param name="accountNumber">The existing account number</param>
        public void CloseAccount(string accountNumber)
        {
            Account account = GetAccount(accountNumber);
            _accounts.Remove(account);
        }

        /// <summary>
        /// Deposits given amount to the account with given account number
        /// </summary>
        /// <param name="accountNumber">The account number</param>
        /// <param name="amount">The amount to deposit</param>
        /// <param name="bonus">The bonus points to add</param>
        public void DepositAccount(string accountNumber, decimal amount, int bonus)
        {
            Account account = GetAccount(accountNumber);
            account.CurrentAmount += amount;
            account.BonusCount += bonus;
        }

        /// <summary>
        /// Gets all open accounts
        /// </summary>
        /// <returns>The enumeration of the account instance</returns>
        public IEnumerable<Account> GetAccounts()
        {
            return new List<Account>(_accounts);
        }

        /// <summary>
        /// Opens new account
        /// </summary>
        /// <param name="account">New account</param>
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

        /// <summary>
        /// Withdraws given amount from the account with given account number
        /// </summary>
        /// <param name="accountNumber">The account number</param>
        /// <param name="amount">The amount to withdraw</param>
        /// <param name="bonus">The bonus points to subtract</param>
        public void WithdrawAccount(string accountNumber, decimal amount, int bonus)
        {
            Account account = GetAccount(accountNumber);
            account.CurrentAmount -= amount;
            account.BonusCount -= bonus;
        }

        /// <summary>
        /// Gets the account using it's number
        /// </summary>
        /// <param name="accountNumber">The number of the account</param>
        /// <returns>The account with given number</returns>
        public Account GetAccount(string accountNumber)
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
