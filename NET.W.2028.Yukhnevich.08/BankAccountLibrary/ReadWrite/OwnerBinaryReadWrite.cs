using System;
using System.IO;

namespace BankAccountLibrary.ReadWrite
{
    public class OwnerBinaryReadWrite : IReadWrite<Owner>
    {
        private BinaryWriter writer;
        private BinaryReader reader;

        public OwnerBinaryReadWrite(BinaryReader reader, BinaryWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

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
