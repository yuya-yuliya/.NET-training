using System.Collections.Generic;
using System.IO;
using BankAccountLibrary.Bonus;

namespace BankAccountLibrary.ReadWrite
{
    /// <summary>
    /// Class provides methods for read and write in binary form to file of bank account information
    /// </summary>
    public class AccountBinaryReadWrite : ICollectionReadWrite<BankAccount>
    {
        /// <summary>
        /// Path to read/write file
        /// </summary>
        public readonly string Path;

        /// <summary>
        /// Initializes a new instance of the AccountBinaryReadWrite class that has path to read/write file
        /// </summary>
        /// <param name="path">Path to read/write file</param>
        public AccountBinaryReadWrite(string path)
        {
            Path = path;
        }

        /// <summary>
        /// Read the information of bank account from file
        /// </summary>
        /// <returns>New instance of bank account that has information</returns>
        public BankAccount Read()
        {
            using (BinaryReader reader = new BinaryReader(File.OpenRead(Path)))
            {
                return ReadAccount(reader);
            }
        }

        /// <summary>
        /// Write the information of bank account in file
        /// </summary>
        /// <param name="item">Instance of bank account that has information to write</param>
        public void Write(BankAccount item)
        {
            using (BinaryWriter writer = new BinaryWriter(File.OpenWrite(Path)))
            {
                WriteAccount(writer, item);
            }
        }

        /// <summary>
        /// Write collection of bank accounts in file in binary form
        /// </summary>
        /// <param name="items">Collection of bank accounts</param>
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

        /// <summary>
        /// Read collection of bank accounts from file in binary form
        /// </summary>
        /// <returns>Collection of bank accounts</returns>
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

        /// <summary>
        /// Read the information of bank account from binary reader
        /// </summary>
        /// <param name="reader">Binary reader for reading</param>
        /// <returns>New instance of bank account that has information</returns>
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

        /// <summary>
        /// Write the information of bank account using binary writer
        /// </summary>
        /// <param name="writer">Binary writer for writing</param>
        /// <param name="account">Instance of bank account</param>
        private void WriteAccount(BinaryWriter writer, BankAccount account)
        {
            writer.Write(account.AccountNumber);
            new OwnerBinaryReadWrite(null, writer).Write(account.AccountOwner);
            writer.Write(account.Amount);
            writer.Write(account.Bonus.GetType().ToString());
            writer.Write(account.BonusCount);
            writer.Write(account.IsClosed);
        }
    }
}
