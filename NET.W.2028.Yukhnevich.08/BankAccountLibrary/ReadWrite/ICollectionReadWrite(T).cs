using System.Collections.Generic;

namespace BankAccountLibrary.ReadWrite
{
    public interface ICollectionReadWrite<T>
    {
        ICollection<T> CollectionRead();
        void CollectionWrite(ICollection<T> items);
    }
}
