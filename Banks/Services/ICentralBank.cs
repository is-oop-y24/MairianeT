using System.Collections.Generic;
using Banks.Entities;

namespace Banks.Services
{
    public interface ICentralBank
    {
        Client NewClient(ClientBuilder builder);

        Bank NewBank(BankBuilder builder);

        Account NewDebitAccountInBank(Bank bank, Client client, double sum);
        Account NewDepositAccountInBank(Bank bank, Client client, double sum, int term);
        Account NewCreditAccountInBank(Bank bank, Client client, double sum);

        void RewindTime(int days);

        void ChangeCreditLimit(Bank bank, double newLimit);
        void ChangePercent(Bank bank, double newPercent);

        void Subscribe(Bank bank, Client client);

        void RefillCash(Bank bank, Client client, Account account, double sum);
        void WithdrawalCash(Bank bank, Client client, Account account, double sum);
        void Transfer(Bank bank, Client client1, Client client2, Account account1, Account account2, double sum);
        void CancelTransaction(Account account);
        List<Bank> GetBanks();
        List<Client> GetClients();
    }
}