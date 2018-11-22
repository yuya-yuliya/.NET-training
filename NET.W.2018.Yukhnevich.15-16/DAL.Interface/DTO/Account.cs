using System;
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
        /// The account bonus counting system
        /// </summary>
        private IBonus _bonus;

        /// <summary>
        /// Initialize new instance of Account class
        /// </summary>
        /// <param name="accountNumber">The account number</param>
        /// <param name="owner">The owner of the account</param>
        /// <param name="bonus">The account bonus counting system</param>
        public Account(string accountNumber, Owner owner, IBonus bonus)
        {
            AccountNumber = accountNumber;
            AccountOwner = owner;
            _bonus = bonus;
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
        /// The account bonus counting system
        /// </summary>
        public IBonus Bonus
        {
            get => _bonus;
            private set
            {
                _bonus = value;
            }
        }

        /// <summary>
        /// The account current amount
        /// </summary>
        public decimal CurrentAmount
        {
            get;
            private set;
        }

        /// <summary>
        /// Withdraws given amount
        /// </summary>
        /// <param name="amount">The amount to withdraw</param>
        public void Withdraw(decimal amount)
        {
            CurrentAmount -= amount;
            if (_bonus != null)
            {
                _bonus.SubBonus(amount);
            }
        }

        /// <summary>
        /// Deposits given amount
        /// </summary>
        /// <param name="amount">The amount to deposit</param>
        public void Deposit(decimal amount)
        {
            CurrentAmount += amount;
            if (_bonus != null)
            {
                _bonus.AddBonus(amount);
            }
        }

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
        /// Provides the string representation of current account
        /// </summary>
        /// <returns>The string representation of current account</returns>
        public override string ToString()
        {
            return $"Account number: {AccountNumber} Owner: \"{AccountOwner}\" Current amount: {CurrentAmount}" + 
                (_bonus != null ? $" Bonus score: {_bonus.BonusScore}" : string.Empty);
        }
    }
}
