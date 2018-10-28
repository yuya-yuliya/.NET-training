using System;
using System.IO;

namespace BankAccountLibrary.ReadWrite
{
    /// <summary>
    /// Class provides methods for read and wtite in binary form to file of owner information
    /// </summary>
    public class OwnerBinaryReadWrite : IReadWrite<Owner>
    {
        private BinaryWriter writer;
        private BinaryReader reader;

        /// <summary>
        /// Initializes a new instance of the OwnerBinaryReadWrite class that has binary reader and(or) writer
        /// </summary>
        /// <param name="reader">Binary reader</param>
        /// <param name="writer">Binary writer</param>
        public OwnerBinaryReadWrite(BinaryReader reader, BinaryWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        /// <summary>
        /// Read the information of owner from binary reader
        /// </summary>
        /// <returns>New instance of owner that has information</returns>
        public Owner Read()
        {
            if (reader == null)
            {
                throw new MethodAccessException("Binary reader is null");
            }
            string name = reader.ReadString();
            string surname = reader.ReadString();
            return new Owner(name, surname);
        }

        /// <summary>
        /// Write the information of bank account using binary writer
        /// </summary>
        /// <param name="item">Instance of owner that has information to write</param>
        public void Write(Owner item)
        {
            if (writer == null)
            {
                throw new MethodAccessException("Binary writer is null");
            }
            writer.Write(item.Name);
            writer.Write(item.Surname);
        }
    }
}
