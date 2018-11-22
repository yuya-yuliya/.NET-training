namespace BLL.Interface.Interfaces
{
    /// <summary>
    /// Provides method for creating unique account numbers
    /// </summary>
    public interface IAccountNumberCreateService
    {
        /// <summary>
        /// Creates unique account number
        /// </summary>
        /// <returns>the string that represents account number</returns>
        string GetNumber();
    }
}
