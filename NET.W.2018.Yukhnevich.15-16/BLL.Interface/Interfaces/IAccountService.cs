﻿using System.Collections.Generic;
using BLL.Interface.Entities;
using DAL.Interface.DTO;

namespace BLL.Interface.Interfaces
{
    /// <summary>
    /// Provides methods to interact with accounts data
    /// </summary>
    public interface IAccountService
    {
        /// <summary>
        /// Opens new account
        /// </summary>
        /// <param name="accountOwner">The owner of new account</param>
        /// <param name="accountType">The account type</param>
        /// <param name="numberCreateService">The service for creating account number</param>
        void OpenAccount(string accountOwner, Entities.AccountType accountType, IAccountNumberCreateService numberCreateService);
        
        /// <summary>
        /// Closes the account
        /// </summary>
        /// <param name="accountNumber">The existing account number</param>
        void CloseAccount(string accountNumber);

        /// <summary>
        /// Gets all open accounts
        /// </summary>
        /// <returns>The enumeration of the account instance</returns>
        IEnumerable<Entities.Account> GetAllAccounts();

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
        /// <param name="accountNumber">The number of the account</param>
        /// <returns>The account with given number</returns>
        Entities.Account GetAccount(string accountNumber);

        /// <summary>
        /// Transfers the amount from one account to other
        /// </summary>
        /// <param name="fromAccountNumber">The account to withdraw</param>
        /// <param name="toAccountNumber">The account to deposit</param>
        /// <param name="amount">The transfer amount</param>
        void Transfer(string fromAccountNumber, string toAccountNumber, decimal amount);
    }
}
