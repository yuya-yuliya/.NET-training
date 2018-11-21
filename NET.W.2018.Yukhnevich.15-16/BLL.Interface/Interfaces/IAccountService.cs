using BLL.Interface.Entities;
using DAL.Interface.DTO;
using System.Collections.Generic;


namespace BLL.Interface.Interfaces
{
    public interface IAccountService
    {
        void OpenAccount(string accountOwner, AccountType accountType, IAccountNumberCreateService numberCreateService);
        void CloseAccount(string accountNumber);
        IEnumerable<Account> GetAllAccounts();
        void DepositAccount(string accountNumber, decimal amount);
        void WithdrawAccount(string accountNumber, decimal amount);
    }
}
