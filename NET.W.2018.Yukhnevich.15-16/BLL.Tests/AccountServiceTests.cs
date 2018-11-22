using System.Collections.Generic;
using NUnit.Framework;
using Moq;
using DAL.Interface.Interfaces;
using DAL.Interface.DTO;
using BLL.ServiceImplementation;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;

namespace BLL.Tests
{
    [TestFixture]
    public class AccountServiceTests
    {
        [Test]
        public void GetAllAccounts_CorrectResult()
        {
            List<Account> accounts = new List<Account>
            {
                new Account("1", new Owner("A", "B"), null),
                new Account("2", new Owner("C", "B"), null),
                new Account("3", new Owner("D", "B"), null),
            };
            var mock = new Mock<IRepository>();
            mock.Setup(m => m.GetAccounts()).Returns(new List<Account>(accounts));
            var accountService = new AccountService(mock.Object);

            var result = accountService.GetAllAccounts();

            Assert.AreEqual(accounts, result);
        }

        [Test]
        public void OpenAccount_AddAccount()
        {
            var bonusMock = new Mock<IBonus>();
            bonusMock.Setup(m => m.BonusScore).Returns(0);
            var numberCreateMock = new Mock<IAccountNumberCreateService>();
            numberCreateMock.Setup(m => m.GetNumber()).Returns("1");
            Account account = new Account("1", new Owner("A", "B"), bonusMock.Object);
            var mock = new Mock<IRepository>();
            mock.Setup(m => m.GetAccounts()).Returns(new List<Account>());
            var accountService = new AccountService(mock.Object);

            accountService.OpenAccount(account.AccountOwner.ToString(), AccountType.Base, numberCreateMock.Object);

            mock.Verify(a => a.OpenAccount(account));
            numberCreateMock.Verify(a => a.GetNumber());
        }

        [Test]
        public void CloseAccount_RemoveAccount()
        {
            var bonusMock = new Mock<IBonus>();
            bonusMock.Setup(m => m.BonusScore).Returns(0);
            var numberCreateMock = new Mock<IAccountNumberCreateService>();
            numberCreateMock.Setup(m => m.GetNumber()).Returns("1");
            Account account = new Account("1", new Owner("A", "B"), bonusMock.Object);
            var mock = new Mock<IRepository>();
            mock.Setup(m => m.GetAccounts()).Returns(new List<Account> { account });
            var accountService = new AccountService(mock.Object);

            accountService.CloseAccount(account.AccountNumber);

            mock.Verify(a => a.CloseAccount(account.AccountNumber));
        }

        [Test]
        public void DepositAccount_AmountAndBonusIncreased()
        {
            var bonusMock = new Mock<IBonus>();
            bonusMock.Setup(m => m.BonusScore).Returns(0);
            var numberCreateMock = new Mock<IAccountNumberCreateService>();
            numberCreateMock.Setup(m => m.GetNumber()).Returns("1");
            Account account = new Account("1", new Owner("A", "B"), bonusMock.Object);
            var mock = new Mock<IRepository>();
            mock.Setup(m => m.GetAccounts()).Returns(new List<Account> { account });
            var accountService = new AccountService(mock.Object);
            decimal deposit = 100;

            accountService.DepositAccount(account.AccountNumber, deposit);

            mock.Verify(a => a.DepositAccount(account.AccountNumber, deposit));
        }

        [Test]
        public void WithdrawAccount_AmountAndBonusDecreased()
        {
            var bonusMock = new Mock<IBonus>();
            bonusMock.Setup(m => m.BonusScore).Returns(0);
            var numberCreateMock = new Mock<IAccountNumberCreateService>();
            numberCreateMock.Setup(m => m.GetNumber()).Returns("1");
            Account account = new Account("1", new Owner("A", "B"), bonusMock.Object);
            var mock = new Mock<IRepository>();
            mock.Setup(m => m.GetAccounts()).Returns(new List<Account> { account });
            var accountService = new AccountService(mock.Object);
            decimal deposit = 100;

            accountService.WithdrawAccount(account.AccountNumber, deposit);

            mock.Verify(a => a.WithdrawAccount(account.AccountNumber, deposit));
        }
    }
}
