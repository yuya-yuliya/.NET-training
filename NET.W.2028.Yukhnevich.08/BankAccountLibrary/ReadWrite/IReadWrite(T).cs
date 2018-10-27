namespace BankAccountLibrary.ReadWrite
{
    public interface IReadWrite<T>
    {
        T Read();
        void Write(T item);
    }
}
