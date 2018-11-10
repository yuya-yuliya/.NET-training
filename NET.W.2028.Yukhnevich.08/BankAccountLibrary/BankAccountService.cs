using System;
using System.Collections.Generic;
using BankAccountLibrary.Bonus;

namespace BankAccountLibrary
{
    /// <summary>
    /// Provides the methods to work with bank account
    /// </summary>
    public class BankAccountService
    {
        /// <summary>
        /// Enumeration of account types
        /// </summary>
        public enum AccountType
        {
            Base,
            Gold,
            Platinum
        }

        /// <summary>
        /// Create new instance of BankAccount class with needed information
        /// </summary>
        /// <param name="accountNumber">Identification number of the account</param>
        /// <param name="owner">The owner information of the account</param>
        /// <param name="accountType">Type of account</param>
        /// <param name="startAmount">The account start amount</param>
        public static BankAccount CreateAccount(string accountNumber, Owner owner, AccountType accountType, decimal startAmount)
        {
            Dictionary<AccountType, IBonus> bonusTypeDict = new Dictionary<AccountType, IBonus>
            {
                [AccountType.Base] = new BaseBonus(),
                [AccountType.Gold] = new GoldBonus(),
                [AccountType.Platinum] = new PlatinumBonus()
            };
            return new BankAccount(accountNumber, owner, bonusTypeDict[accountType], startAmount);
        }

        /// <summary>
        /// Deposit the amount to the account
        /// </summary>
        /// <param name="account">The bank account</param>
        /// <param name="amount">Amount to deposit</param>
        /// <exception cref="MethodAccessException">Account was closed</exception>
        /// <exception cref="ArgumentOutOfRangeException">Amount is negative number</exception>
        public static void Deposit(BankAccount account, decimal amount)
        {
            account.Deposit(amount);
        }

        /// <summary>
        /// Withdraw the amount from account
        /// </summary>
        /// <param name="account">The bank account</param>
        /// <param name="amount">Amount to withdraw</param>
        /// <exception cref="MethodAccessException">Account was closed</exception>
        /// <exception cref="ArgumentOutOfRangeException">Amount is negative number</exception>
        /// <exception cref="Exception">Current account amount is less then withdraw amount</exception>
        public static void Withdraw(BankAccount account, decimal amount)
        {
            account.Withdraw(amount);
        }

        /// <summary>
        /// Close the account
        /// </summary>
        /// <param name="account">The bank account to close</param>
        public static void CloseAccount(BankAccount account)
        {
            account.Close();
        }
    }
}
