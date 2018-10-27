using System;
using System.Collections.Generic;
using System.Linq;
using BankAccountLibrary;
using BankAccountLibrary.ReadWrite;

namespace ConsoleBankShow
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAccount account1 = BankAccountService.CreateAccount("1", new Owner("John", "Doe"), BankAccountService.AccountType.Base, 100),
                account2 = BankAccountService.CreateAccount("2", new Owner("Jane", "Doe"), BankAccountService.AccountType.Gold, 200);

            Console.WriteLine("Create account:");
            PrintAccount(account1);

            Console.WriteLine("\nDeposit:");
            account1.Deposit(20);
            PrintAccount(account1);

            Console.WriteLine("\nWithdraw:");
            account1.Withdraw(50);
            PrintAccount(account1);

            Console.WriteLine("\nClose account:");
            account1.Close();
            PrintAccount(account1);

            if (args.Length >= 1)
            {
                AccountBinaryReadWrite binaryReadWrite = new AccountBinaryReadWrite(args[0]);
                List<BankAccount> accounts = new List<BankAccount>();
                try
                {
                    accounts = binaryReadWrite.CollectionRead().ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.WriteLine("\nRead list from file:");
                PrintAccounts(accounts);

                Console.WriteLine("\nAdd account:");
                accounts.Add(account2);
                PrintAccount(account2);

                Console.WriteLine("\nDeposit first:");
                accounts[0].Deposit(50);
                PrintAccount(accounts[0]);

                Console.WriteLine("\nSave to file:");
                binaryReadWrite.CollectionWrite(accounts);
                PrintAccounts(accounts);
            }
            else
            {
                Console.WriteLine("Enter source path");
            }

            Console.ReadLine();
        }

        static void PrintAccount(BankAccount account)
        {
            Console.WriteLine(account.ToString());
        }

        static void PrintAccounts(ICollection<BankAccount> accounts)
        {
            foreach (BankAccount account in accounts)
            {
                Console.WriteLine(account.ToString());
                Console.WriteLine();
            }
        }
    }
}
