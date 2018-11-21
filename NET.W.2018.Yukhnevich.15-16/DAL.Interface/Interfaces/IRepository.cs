using DAL.Interface.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.Interfaces
{
    public interface IRepository
    {
        void OpenAccount(Account account);
        void CloseAccount(string accountNumber);
        void DepositAccount(string accountNumber, decimal amount);
        void WithdrawAccount(string accountNumber, decimal amount);
        IEnumerable<Account> GetAccounts();
    }
}
