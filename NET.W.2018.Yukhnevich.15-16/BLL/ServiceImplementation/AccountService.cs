using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interface.Interfaces;
using BLL.Mappers;
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
            DAL.Interface.DTO.Account account = _repository.GetAccount(accountNumber);
            IBonus bonus = new BonusCounter().GetBonus(AccountTypeMapper.GetBusinessAccountType(account.AccountType));
            _repository.DepositAccount(accountNumber, amount, bonus.GetAddBonus(amount));
        }

        /// <summary>
        /// Gets all accounts in the repository
        /// </summary>
        /// <returns>The accounts enumeration</returns>
        public IEnumerable<Interface.Entities.Account> GetAllAccounts()
        {
            return _repository.GetAccounts().Select(acc => AccountMapper.MapToBusiness(acc));
        }

        /// <summary>
        /// Opens new account with given information
        /// </summary>
        /// <param name="accountOwner">The owner of the account</param>
        /// <param name="accountType">The account type</param>
        /// <param name="numberCreateService">Service for creating unique account number</param>
        public void OpenAccount(string accountOwner, Interface.Entities.AccountType accountType, IAccountNumberCreateService numberCreateService)
        {
            string accountNumber = numberCreateService.GetNumber();
            Interface.Entities.Account account = new Interface.Entities.Account(accountNumber, accountOwner, accountType);

            _repository.OpenAccount(AccountMapper.MapToData(account));
        }

        /// <summary>
        /// Withdraws the amount from the account with given account number
        /// </summary>
        /// <param name="accountNumber">String of the account number</param>
        /// <param name="amount">The amount to withdraw</param>
        public void WithdrawAccount(string accountNumber, decimal amount)
        {
            DAL.Interface.DTO.Account account = _repository.GetAccount(accountNumber);
            IBonus bonus = new BonusCounter().GetBonus(AccountTypeMapper.GetBusinessAccountType(account.AccountType));
            _repository.WithdrawAccount(accountNumber, amount, bonus.GetSubBonus(amount));
        }
    }
}
