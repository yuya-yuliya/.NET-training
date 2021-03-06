﻿using System;
using System.Collections.Generic;
using DAL.Interface.Interfaces;

namespace DAL.Interface.DTO
{
    /// <summary>
    /// Represents information about the account and allows to interact with it
    /// </summary>
    public class Account
    {
        /// <summary>
        /// The account number
        /// </summary>
        private string _accountNumber;

        /// <summary>
        /// The account owner
        /// </summary>
        private Owner _accountOwner;

        /// <summary>
        /// Initialize new instance of Account class
        /// </summary>
        /// <param name="accountNumber">The account number</param>
        /// <param name="owner">The owner of the account</param>
        /// <param name="accountType">The account type</param>
        public Account(string accountNumber, Owner owner, AccountType accountType)
        {
            AccountNumber = accountNumber;
            AccountOwner = owner;
            AccountType = accountType;
        }

        /// <summary>
        /// The account number
        /// </summary>
        public string AccountNumber
        {
            get => _accountNumber;
            private set
            {
                if (value != null && value != string.Empty)
                {
                    _accountNumber = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        /// <summary>
        /// The account owner
        /// </summary>
        public Owner AccountOwner
        {
            get => _accountOwner;
            private set
            {
                if (value != null)
                {
                    _accountOwner = value;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
        }

        /// <summary>
        /// The count of bonus points
        /// </summary>
        public int BonusCount { get; set; }

        /// <summary>
        /// The account type
        /// </summary>
        public AccountType AccountType { get; set; }

        /// <summary>
        /// The account current amount
        /// </summary>
        public decimal CurrentAmount { get; set; }

        /// <summary>
        /// Checks the equality
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (this == obj)
            {
                return true;
            }

            if (obj == null || obj.GetType() != this.GetType())
            {
                return false;
            }

            Account account = (Account)obj;
            return account._accountNumber == this._accountNumber &&
                this._accountOwner.Equals(account._accountOwner);
        }

        /// <summary>
        /// Gets hash code of current instance
        /// </summary>
        /// <returns>The hash code</returns>
        public override int GetHashCode()
        {
            var hashCode = -120320503;
            hashCode = (hashCode * -1521134295) + EqualityComparer<string>.Default.GetHashCode(_accountNumber);
            hashCode = (hashCode * -1521134295) + EqualityComparer<Owner>.Default.GetHashCode(_accountOwner);
            hashCode = (hashCode * -1521134295) + BonusCount.GetHashCode();
            hashCode = (hashCode * -1521134295) + AccountType.GetHashCode();
            hashCode = (hashCode * -1521134295) + CurrentAmount.GetHashCode();
            return hashCode;
        }
    }
}
