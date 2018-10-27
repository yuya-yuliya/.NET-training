using BankAccountLibrary.Bonus;
using System.Collections.Generic;
using System.IO;

namespace BankAccountLibrary.ReadWrite
{
    public class AccountBinaryReadWrite : IReadWrite<BankAccount>, ICollectionReadWrite<BankAccount>
    {
        public readonly string Path;

        public AccountBinaryReadWrite(string path)
        {
            Path = path;
        }

        public BankAccount Read()
        {
            using (BinaryReader reader = new BinaryReader(File.OpenRead(Path)))
            {
                return ReadAccount(reader);
            }
        }

        public void Write(BankAccount item)
        {
            using (BinaryWriter writer = new BinaryWriter(File.OpenWrite(Path)))
            {
                WriteAccount(writer, item);
            }
        }

        public void CollectionWrite(ICollection<BankAccount> items)
        {
            using (BinaryWriter writer = new BinaryWriter(File.OpenWrite(Path)))
            {
                foreach (BankAccount account in items)
                {
                    WriteAccount(writer, account);
                }
            }
        }

        public ICollection<BankAccount> CollectionRead()
        {
            List<BankAccount> accounts = new List<BankAccount>();
            using (BinaryReader reader = new BinaryReader(File.OpenRead(Path)))
            {
                while (reader.PeekChar() > -1)
                {
                    accounts.Add(ReadAccount(reader));
                }
            }
            return accounts;
        }

        private BankAccount ReadAccount(BinaryReader reader)
        {
            string accountNumber = reader.ReadString();
            Owner owner = new OwnerBinaryReadWrite(reader, null).Read();
            decimal amount = reader.ReadDecimal();
            string bonusType = reader.ReadString();
            int bonusCount = reader.ReadInt32();
            bool isClosed = reader.ReadBoolean();
            BankAccount bankAccount = new BankAccount(accountNumber, owner, BonusCreator.Create(bonusType, bonusCount), amount);
            if (isClosed)
            {
                bankAccount.Close();
            }
            return bankAccount;
        }

        private void WriteAccount(BinaryWriter writer, BankAccount account)
        {
            writer.Write(account.AccountNumber);
            new OwnerBinaryReadWrite(null, writer).Write(account.AccountOwner);
            writer.Write(account.Amount);
            writer.Write(account.bonus.GetType().ToString());
            writer.Write(account.BonusCount);
            writer.Write(account.IsClosed);
        }
    }
}
