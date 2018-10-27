using BankAccountLibrary.Bonus;
using System;
using System.Threading;

namespace BankAccountLibrary
{
    public class BankAccount
    {
        internal IBonus bonus;
        private int isClosed;
        private object locker = new object();
        private const string negativeAmountEx = "Amount must be positive number";
        private const string accountClosedEx = "Account has already closed";

        public readonly string AccountNumber;
        public readonly Owner AccountOwner;
        public decimal Amount { get; private set; }
        public bool IsClosed => isClosed != 0;
        public int BonusCount
        {
            get
            {
                return bonus.BonusCount;
            }
        }

        public BankAccount(string accountNumber, Owner owner, IBonus bonus, decimal startAmount = 0)
        {
            AccountNumber = accountNumber;
            AccountOwner = owner;
            this.bonus = bonus;
            Amount = startAmount;
            isClosed = 0;
        }

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

        public void Close()
        {
            Interlocked.Exchange(ref isClosed, 1);
        }

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
