using NUnit.Framework;
using Moq;
using DAL.Interface.Interfaces;
using DAL.Interface.DTO;
using BLL.ServiceImplementation;
using BLL.Interface.Interfaces;

namespace BLL.Tests
{
    [TestFixture]
    public class AccountServiceTests
    {
        [Test]
        public void GetAllAccounts_CorrectResult()
        {
            var mock = new Mock<IRepository>();
            var accountService = new AccountService(mock.Object);

            accountService.GetAllAccounts();

            mock.Verify(a => a.GetAccounts());
        }

        [Test]
        public void OpenAccount_AddAccount()
        {
            var numberCreateMock = new Mock<IAccountNumberCreateService>();
            numberCreateMock.Setup(m => m.GetNumber()).Returns("1");
            Account account = new Account("1", new Owner("A", "B"), AccountType.Base);
            var mock = new Mock<IRepository>();
            var accountService = new AccountService(mock.Object);

            accountService.OpenAccount(account.AccountOwner.ToString(), Interface.Entities.AccountType.Base, numberCreateMock.Object);

            mock.Verify(a => a.OpenAccount(account));
            numberCreateMock.Verify(a => a.GetNumber());
        }

        [Test]
        public void CloseAccount_RemoveAccount()
        {
            var mock = new Mock<IRepository>();
            var accountService = new AccountService(mock.Object);

            accountService.CloseAccount("1");

            mock.Verify(a => a.CloseAccount("1"));
        }

        [Test]
        public void DepositAccount_AmountAndBonusIncreased()
        {
            Account account = new Account("1", new Owner("A", "B"), AccountType.Base);
            var mock = new Mock<IRepository>();
            mock.Setup(m => m.GetAccount(account.AccountNumber)).Returns(account);
            var accountService = new AccountService(mock.Object);
            decimal deposit = 100;
            int bonus = new BonusCounter().GetBonus(Interface.Entities.AccountType.Base).GetAddBonus(deposit);

            accountService.DepositAccount(account.AccountNumber, deposit);

            mock.Verify(a => a.DepositAccount(account.AccountNumber, deposit, bonus));
        }

        [Test]
        public void WithdrawAccount_AmountAndBonusDecreased()
        {
            Account account = new Account("1", new Owner("A", "B"), AccountType.Base);
            var mock = new Mock<IRepository>();
            mock.Setup(m => m.GetAccount(account.AccountNumber)).Returns(account);
            var accountService = new AccountService(mock.Object);
            decimal deposit = 100;
            int bonus = new BonusCounter().GetBonus(Interface.Entities.AccountType.Base).GetSubBonus(deposit);

            accountService.WithdrawAccount(account.AccountNumber, deposit);

            mock.Verify(a => a.WithdrawAccount(account.AccountNumber, deposit, bonus));
        }
    }
}
