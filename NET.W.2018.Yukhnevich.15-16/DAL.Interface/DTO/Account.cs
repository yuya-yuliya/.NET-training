using DAL.Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.DTO
{
    public class Account
    {
        private string _accountNumber;
        private Owner _accountOwner;
        private IBonus _bonus;

        public Account(string accountNumber, Owner owner, IBonus bonus)
        {
            AccountNumber = accountNumber;
            AccountOwner = owner;
            _bonus = bonus;
        }

        public string AccountNumber
        {
            get => _accountNumber;
            private set
            {
                if (value != null && value != "")
                {
                    _accountNumber = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

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

        public IBonus Bonus
        {
            get => _bonus;
            private set
            {
                _bonus = value;
            }
        }

        public decimal CurrentAmount
        {
            get;
            private set;
        }

        public void Withdraw(decimal amount)
        {
            CurrentAmount -= amount;
            if (_bonus != null)
            {
                _bonus.SubBonus(amount);
            }
        }

        public void Deposit(decimal amount)
        {
            CurrentAmount += amount;
            if (_bonus != null)
            {
                _bonus.AddBonus(amount);
            }
        }

        public override string ToString()
        {
            return $"Account number: {AccountNumber} Owner: \"{AccountOwner}\" Current amount: {CurrentAmount}" + 
                (_bonus != null ? $" Bonus score: {_bonus.BonusScore}" : "");
        }
    }
}
