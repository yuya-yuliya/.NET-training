using System.Collections.Generic;
using DAL.Interface.DTO;

namespace DAL.Interface.Interfaces
{
    /// <summary>
    /// Provides methods for working with repositories
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Opens new account
        /// </summary>
        /// <param name="account">New account</param>
        void OpenAccount(Account account);

        /// <summary>
        /// Closes the account
        /// </summary>
        /// <param name="accountNumber">The existing account number</param>
        void CloseAccount(string accountNumber);

        /// <summary>
        /// Deposits given amount to the account with given account number
        /// </summary>
        /// <param name="accountNumber">The account number</param>
        /// <param name="amount">The amount to deposit</param>
        /// <param name="bonus">The bonus points to add</param>
        void DepositAccount(string accountNumber, decimal amount, int bonus);

        /// <summary>
        /// Withdraws given amount from the account with given account number
        /// </summary>
        /// <param name="accountNumber">The account number</param>
        /// <param name="amount">The amount to withdraw</param>
        /// <param name="bonus">The bonus points to subtract</param>
        void WithdrawAccount(string accountNumber, decimal amount, int bonus);

        /// <summary>
        /// Gets all accounts in repository
        /// </summary>
        /// <returns>The enumeration of the accounts</returns>
        IEnumerable<Account> GetAccounts();

        /// <summary>
        /// Gets the account using it's number
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <returns>The accounts with given number</returns>
        Account GetAccount(string accountNumber);
    }
}
