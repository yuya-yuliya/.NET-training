using System;
using System.Collections.Generic;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using BLL.Mappers;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;

namespace BLL.ServiceImplementation
{
    /// <summary>
    /// Represents the service for working with banc accounts
    /// </summary>
    public class AccountService : IAccountService
    {
        /// <summary>
        /// The repository of the accounts
        /// </summary>
        private IRepository _repository;

        /// <summary>
        /// Initialize new instance of AccountService class with given repository
        /// </summary>
        /// <param name="repository">The repository of the accounts</param>
        public AccountService(IRepository repository)
        {
            if (repository != null)
            {
                _repository = repository;
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        /// <summary>
        /// Closes the account with given account number
        /// </summary>
        /// <param name="accountNumber">String of account number</param>
        public void CloseAccount(string accountNumber)
        {
            _repository.CloseAccount(accountNumber);
        }

        /// <summary>
        /// Deposits the amount to the account with given account number
        /// </summary>
        /// <param name="accountNumber">String of the account number</param>
        /// <param name="amount">The amount to deposit</param>
        public void DepositAccount(string accountNumber, decimal amount)
        {
            _repository.DepositAccount(accountNumber, amount);
        }

        /// <summary>
        /// Gets all accounts in the repository
        /// </summary>
        /// <returns>The accounts enumeration</returns>
        public IEnumerable<Account> GetAllAccounts()
        {
            return _repository.GetAccounts();
        }

        /// <summary>
        /// Opens new account with given information
        /// </summary>
        /// <param name="accountOwner">The owner of the account</param>
        /// <param name="accountType">The account type</param>
        /// <param name="numberCreateService">Service for creating unique account number</param>
        public void OpenAccount(string accountOwner, AccountType accountType, IAccountNumberCreateService numberCreateService)
        {
            string accountNumber = numberCreateService.GetNumber();
            Owner owner = ParseOwner(accountOwner);
            IBonus bonus = new AccountTypeMapper().CreateBonus(accountType);
            Account account = new Account(accountNumber, owner, bonus);

            _repository.OpenAccount(account);
        }

        /// <summary>
        /// Withdraws the amount from the account with given account number
        /// </summary>
        /// <param name="accountNumber">String of the account number</param>
        /// <param name="amount">The amount to withdraw</param>
        public void WithdrawAccount(string accountNumber, decimal amount)
        {
            _repository.WithdrawAccount(accountNumber, amount);
        }

        /// <summary>
        /// Parse owner string to the instance of Owner class
        /// </summary>
        /// <param name="ownerStr">The owner string</param>
        /// <returns>The instance of Owner class</returns>
        private Owner ParseOwner(string ownerStr)
        {
            string separator = " ";
            string[] ownerNameParts = ownerStr.Split(separator.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            if (ownerNameParts.Length < 2)
            {
                throw new ArgumentException("Owner must have first and last names separeted by space");
            }

            string[] secondNameParts = new string[ownerNameParts.Length - 1];
            Array.Copy(ownerNameParts, 1, secondNameParts, 0, secondNameParts.Length);
            string secondName = string.Join(separator, secondNameParts);
            return new Owner(ownerNameParts[0], secondName);
        }
    }
}
