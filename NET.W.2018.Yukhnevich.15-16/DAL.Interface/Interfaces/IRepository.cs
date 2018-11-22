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
        void DepositAccount(string accountNumber, decimal amount);

        /// <summary>
        /// Withdraws given amount from the account with given account number
        /// </summary>
        /// <param name="accountNumber">The account number</param>
        /// <param name="amount">The amount to withdraw</param>
        void WithdrawAccount(string accountNumber, decimal amount);

        /// <summary>
        /// Gets the account using it's number
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <returns>The enumeration of the accounts</returns>
        IEnumerable<Account> GetAccounts();
    }
}
