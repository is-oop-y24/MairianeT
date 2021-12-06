using System;
using NUnit.Framework;
using Banks.Entities;
using Banks.Services;
using Banks.Tools;

namespace Banks.Tests
{
    public class BankTests
    {
        private ICentralBank _centralBank;

        [SetUp]
        public void Setup()
        {
            _centralBank = new CentralBank();
        }

        [Test]
        public void AddClientWithoutVerified_TryToRefillMoney()
        {
            BankBuilder bankBuilder = new BankBuilder().SetName("VTB").SetPercent(0.01).SetUnverifiedLimit(50);
            Bank bank = _centralBank.NewBank(bankBuilder);
            ClientBuilder clientBuilder = new ClientBuilder().SetName("Pavel").SetSurname("Ivanov");
            Client client = _centralBank.NewClient(clientBuilder);
            Account account = _centralBank.NewDebitAccountInBank(bank, client, 100);
            Assert.Catch<BanksException>((() =>
            {
                _centralBank.RefillCash(bank, client, account, 60);
            }), "test 1");
        }

        [Test]
        public void AddAccountToClient_RewindTime()
        {
             BankBuilder bankBuilder = new BankBuilder().SetName("VTB").SetPercent(0.01);
             Bank bank = _centralBank.NewBank(bankBuilder);
             ClientBuilder clientBuilder = new ClientBuilder().SetName("Pavel").SetSurname("Ivanov").SetAddress("home").SetPassport("1111 222333");
             Client client = _centralBank.NewClient(clientBuilder);
             Account account = _centralBank.NewDebitAccountInBank(bank, client, 100);
             _centralBank.RewindTime(30);
             Assert.True((Math.Abs(account.Balance - 130) < 0.001), "test 2");
        }

        [Test]
        public void CancelTransaction()
        {
            BankBuilder bankBuilder = new BankBuilder().SetName("VTB").SetPercent(0.01).SetUnverifiedLimit(50);
            Bank bank = _centralBank.NewBank(bankBuilder);
            ClientBuilder clientBuilder = new ClientBuilder().SetName("Pavel").SetSurname("Ivanov").SetAddress("home").SetPassport("1111 222333");
            Client client = _centralBank.NewClient(clientBuilder);
            Account account = _centralBank.NewDebitAccountInBank(bank, client, 100);
            _centralBank.WithdrawalCash(bank, client, account,50);
            Assert.True(Math.Abs(account.Balance - 50) < 0.001);
            _centralBank.CancelTransaction(account);
            Assert.True(Math.Abs(account.Balance - 100) < 0.001);
        }
    }
}