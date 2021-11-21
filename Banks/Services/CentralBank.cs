using System.Collections.Generic;
using Banks.Entities;

namespace Banks.Services
{
    public class CentralBank : ICentralBank
    {
        public CentralBank()
        {
            Banks = new List<Bank>();
            Clients = new List<Client>();
        }

        public List<Bank> Banks { get; }
        public List<Client> Clients { get; }
        public Client NewClient(ClientBuilder builder)
        {
            Client client = builder.GetClient();
            Clients.Add(client);
            return client;
        }

        public Bank NewBank(BankBuilder builder)
        {
            Bank bank = builder.GetBank();
            Banks.Add(bank);
            return bank;
        }

        public Account NewDebitAccountInBank(Bank bank, Client client, double sum)
        {
            return bank.AddClientAccount(client, "debit", sum);
        }

        public Account NewDepositAccountInBank(Bank bank, Client client, double sum, int term)
        {
            return bank.AddClientAccount(client, "deposit", sum, term);
        }

        public Account NewCreditAccountInBank(Bank bank, Client client, double sum)
        {
            return bank.AddClientAccount(client, "credit", sum);
        }

        public void RewindTime(int days)
        {
            foreach (Bank bank in Banks)
            {
                bank.RewindTime(days);
            }
        }

        public void ChangeCreditLimit(Bank bank, double newLimit)
        {
            bank.ChangeCreditLimit(newLimit);
        }

        public void ChangePercent(Bank bank, double newPercent)
        {
            bank.ChangePercent(newPercent);
        }

        public void Subscribe(Bank bank, Client client)
        {
            bank.Subscribe(client);
        }

        public void RefillCash(Bank bank, Client client, Account account, double sum)
        {
            bank.RefillCash(client, account, sum);
        }

        public void WithdrawalCash(Bank bank, Client client, Account account, double sum)
        {
            bank.WithdrawalCash(client, account, sum);
        }

        public void Transfer(Bank bank, Client client1, Client client2, Account account1, Account account2, double sum)
        {
            bank.Transfer(client1, client2, account1, account2, sum);
        }

        public void CancelTransaction(Account account)
        {
            account.LastTransaction.CancelTransaction();
        }
    }
}