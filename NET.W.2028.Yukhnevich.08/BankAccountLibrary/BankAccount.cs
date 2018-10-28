using BankAccountLibrary.Bonus;
using System;
using System.Threading;

namespace BankAccountLibrary
{
    /// <summary>
    /// Represents a bank account
    /// </summary>
    public class BankAccount
    {
        internal IBonus bonus;
        private int isClosed;
        private object locker = new object();
        private const string negativeAmountEx = "Amount must be positive number";
        private const string accountClosedEx = "Account has already closed";

        /// <summary>
        /// Identification number of account
        /// </summary>
        public readonly string AccountNumber;
        /// <summary>
        /// The account owner information
        /// </summary>
        public readonly Owner AccountOwner;
        /// <summary>
        /// Corrent amount in the account
        /// </summary>
        public decimal Amount { get; private set; }
        /// <summary>
        /// True if the account is closed, false otherwise
        /// </summary>
        public bool IsClosed => isClosed != 0;
        /// <summary>
        /// Count of bonus in the account
        /// </summary>
        public int BonusCount
        {
            get
            {
                return bonus.BonusCount;
            }
        }

        /// <summary>
        /// Initialize new instance of BankAccount class with needed information
        /// </summary>
        /// <param name="accountNumber">Identification number of the account</param>
        /// <param name="owner">The owner information of the account</param>
        /// <param name="bonus">Bonus counter</param>
        /// <param name="startAmount">The account start amount</param>
        public BankAccount(string accountNumber, Owner owner, IBonus bonus, decimal startAmount = 0)
        {
            AccountNumber = accountNumber;
            AccountOwner = owner;
            this.bonus = bonus;
            Amount = startAmount;
            isClosed = 0;
        }

        /// <summary>
        /// Deposit the amount to the account
        /// </summary>
        /// <param name="amount">Amount to deposit</param>
        /// <exception cref="MethodAccessException">Account was closed</exception>
        /// <exception cref="ArgumentOutOfRangeException">Amount is negative number</exception>
        public void Deposit(decimal amount)
        {
            if (IsClosed)
            {
                throw new MethodAccessException(accountClosedEx);
            }
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(negativeAmountEx);
            }
            lock (locker)
            {
                if (!IsClosed)
                {
                    Amount += amount;
                    bonus.AddBonus();
                }
                else
                {
                    throw new MethodAccessException(accountClosedEx);
                }
            }
        }

        /// <summary>
        /// Withdraw the amount from account
        /// </summary>
        /// <param name="amount">Amount to withdraw</param>
        /// <exception cref="MethodAccessException">Account was closed</exception>
        /// <exception cref="ArgumentOutOfRangeException">Amount is negative number</exception>
        /// <exception cref="Exception">Current account amount is less then withdraw amount</exception>
        public void Withdraw(decimal amount)
        {
            if (IsClosed)
            {
                throw new MethodAccessException(accountClosedEx);
            }
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(negativeAmountEx);
            }
            lock (locker)
            {
                if (!IsClosed)
                {
                    if (Amount - amount < 0)
                    {
                        throw new Exception("Current amount less than withdraw");
                    }
                    Amount -= amount;
                    bonus.SubBonus();
                }
                else
                {
                    throw new MethodAccessException(accountClosedEx);
                }
            }
        }

        /// <summary>
        /// Close the account
        /// </summary>
        public void Close()
        {
            Interlocked.Exchange(ref isClosed, 1);
        }

        /// <summary>
        /// Get the string of the account information
        /// </summary>
        /// <returns>String with the account information</returns>
        public override string ToString()
        {
            return $"Account number: {AccountNumber} " +
                $"Account owner: {AccountOwner.ToString()} " +
                $"Amount: {Amount} " +
                $"Bonus type: {bonus.ToString()} " +
                $"Bonus count: {BonusCount} " +
                $"Is closed: {IsClosed}";
        }
    }
}
