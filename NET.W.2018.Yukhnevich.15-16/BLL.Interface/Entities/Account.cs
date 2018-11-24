using System;

namespace BLL.Interface.Entities
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
        private string _accountOwner;

        /// <summary>
        /// Initialize new instance of Account class
        /// </summary>
        /// <param name="accountNumber">The account number</param>
        /// <param name="owner">The owner of the account</param>
        /// <param name="type">The account type</param>
        public Account(string accountNumber, string owner, AccountType type)
        {
            AccountNumber = accountNumber;
            AccountOwner = owner;
            AccountType = type;
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
        public string AccountOwner
        {
            get => _accountOwner;
            private set
            {
                if (value != null && value != string.Empty)
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
        /// Provides the string representation of current account
        /// </summary>
        /// <returns>The string representation of current account</returns>
        public override string ToString()
        {
            return $"Account number: {AccountNumber} Owner: \"{AccountOwner}\" Current amount: {CurrentAmount}" +
                $"Bonus count: {BonusCount}";
        }
    }
}
