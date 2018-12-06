﻿using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Interface.Interfaces;

namespace DAL.EF.Repositories
{
    /// <summary>
    /// Provides methods for interact with some fake repository of the accounts
    /// </summary>
    public class EFRepository : IRepository
    {
        /// <summary>
        /// Closes the account
        /// </summary>
        /// <param name="accountNumber">The existing account number</param>
        public void CloseAccount(string accountNumber)
        {
            using (BankEntities bankEntities = new BankEntities())
            {
                var account = bankEntities.Account.FirstOrDefault(acc => acc.Number == accountNumber);
                if (account != null)
                {
                    account.IsOpen = false;
                }
                else
                {
                    throw new ArgumentException($"There is no account with number {accountNumber}");
                }

                bankEntities.SaveChanges();
            }
        }

        /// <summary>
        /// Deposits given amount to the account with given account number
        /// </summary>
        /// <param name="accountNumber">The account number</param>
        /// <param name="amount">The amount to deposit</param>
        /// <param name="bonus">The bonus points to add</param>
        public void DepositAccount(string accountNumber, decimal amount, int bonus)
        {
            using (BankEntities bankEntities = new BankEntities())
            {
                var account = bankEntities.Account.FirstOrDefault(acc => acc.Number == accountNumber);
                if (account != null)
                {
                    account.BonusCount -= bonus;
                    account.Amount -= amount;
                }
                else
                {
                    throw new ArgumentException($"There is no account with number {accountNumber}");
                }

                bankEntities.SaveChanges();
            }
        }

        /// <summary>
        /// Gets the account using it's number
        /// </summary>
        /// <param name="accountNumber">The number of the account</param>
        /// <returns>The account with given number</returns>
        public Interface.DTO.Account GetAccount(string accountNumber)
        {
            using (BankEntities bankEntities = new BankEntities())
            {
                return (from account in bankEntities.Account
                        where account.IsOpen && account.Number == accountNumber
                        join owner in bankEntities.Owner
                        on account.OwnerId equals owner.OwnerId
                        select (new Interface.DTO.Account(
                            account.Number,
                            new Interface.DTO.Owner(owner.Name, owner.Surname),
                            AccountTypeConverter.StringToAccountType(account.Type))
                        {
                            CurrentAmount = account.Amount,
                            BonusCount = account.BonusCount
                        })).FirstOrDefault();
            }
        }

        /// <summary>
        /// Gets all open accounts
        /// </summary>
        /// <returns>The enumeration of the account instance</returns>
        public IEnumerable<Interface.DTO.Account> GetAccounts()
        {
            using (BankEntities bankEntities = new BankEntities())
            {
                return (from account in bankEntities.Account
                        where account.IsOpen
                        select (new Interface.DTO.Account(
                            account.Number,
                            new Interface.DTO.Owner(account.Owner.Name, account.Owner.Surname),
                            AccountTypeConverter.StringToAccountType(account.Type))
                        {
                            CurrentAmount = account.Amount,
                            BonusCount = account.BonusCount
                        })).ToList();
            }
        }

        /// <summary>
        /// Opens new account
        /// </summary>
        /// <param name="account">New account</param>
        public void OpenAccount(Interface.DTO.Account account)
        {
            using (BankEntities bankEntities = new BankEntities())
            {
                Owner accOwner = bankEntities.Owner.FirstOrDefault(owner => owner.Name == account.AccountOwner.FirstName && owner.Surname == account.AccountOwner.LastName);
                if (accOwner == null)
                {
                    accOwner = bankEntities.Owner.Add(new Owner() { Name = account.AccountOwner.FirstName, Surname = account.AccountOwner.LastName });
                }

                bankEntities.Account.Add(new Account()
                {
                    Number = account.AccountNumber,
                    Amount = account.CurrentAmount,
                    BonusCount = account.BonusCount,
                    IsOpen = true,
                    Type = AccountTypeConverter.AccountTypeToString(account.AccountType),
                    OwnerId = accOwner.OwnerId
                });
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
            using (BankEntities bankEntities = new BankEntities())
            {
                var account = bankEntities.Account.FirstOrDefault(acc => acc.Number == accountNumber);
                if (account != null)
                {
                    account.BonusCount -= bonus;
                    account.Amount -= amount;
                }
                else
                {
                    throw new ArgumentException($"There is no account with number {accountNumber}");
                }

                bankEntities.SaveChanges();
            }
        }
    }
}
