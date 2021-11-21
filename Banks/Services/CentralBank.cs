using System.Collections.Generic;
using Banks.Entities;

namespace Banks.Services
{
    public class CentralBank : ICentralBank
    {
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

        public void NewDebitAccountInBank(Bank bank, Client client, float sum)
        {
            bank.AddClientAccount(client, "debit", sum);
        }

        public void NewDepositAccountInBank(Bank bank, Client client, float sum, int term)
        {
            bank.AddClientAccount(client, "deposit", sum, term);
        }

        public void NewCreditAccountInBank(Bank bank, Client client, float sum)
        {
            bank.AddClientAccount(client, "credit", sum);
        }

        public void RewindTime(int days)
        {
            foreach (Bank bank in Banks)
            {
                bank.RewindTime(days);
            }
        }

        public void ChangeCreditLimit(Bank bank, float newLimit)
        {
            bank.ChangeCreditLimit(newLimit);
        }

        public void ChangePercent(Bank bank, float newPercent)
        {
            bank.ChangePercent(newPercent);
        }

        public void Subscribe(Bank bank, Client client)
        {
            bank.Subscribe(client);
        }

        public void RefillCash(Bank bank, Client client, Account account, float sum)
        {
            bank.RefillCash(client, account, sum);
        }

        public void WithdrawalCash(Bank bank, Client client, Account account, float sum)
        {
            bank.WithdrawalCash(client, account, sum);
        }

        public void Transfer(Bank bank, Client client1, Client client2, Account account1, Account account2, float sum)
        {
            bank.Transfer(client1, client2, account1, account2, sum);
        }

        public void CancelTransaction(Account account)
        {
            account.LastTransaction.CancelTransaction();
        }
    }
}