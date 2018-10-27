using BankAccountLibrary.Bonus;
using System.Collections.Generic;

namespace BankAccountLibrary
{
    public class BankAccountService
    {
        public enum AccountType
        {
            Base,
            Gold,
            Platinum
        }

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

        public static void Deposit(BankAccount account, decimal amount)
        {
            account.Deposit(amount);
        }

        public static void Withdraw(BankAccount account, decimal amount)
        {
            account.Withdraw(amount);
        }

        public static void CloseAccount(BankAccount account)
        {
            account.Close();
        }
    }
}
