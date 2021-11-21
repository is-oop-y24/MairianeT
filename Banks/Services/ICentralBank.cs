using Banks.Entities;

namespace Banks.Services
{
    public interface ICentralBank
    {
        Client NewClient(ClientBuilder builder);

        Bank NewBank(BankBuilder builder);

        void NewDebitAccountInBank(Bank bank, Client client, float sum);
        void NewDepositAccountInBank(Bank bank, Client client, float sum, int term);
        void NewCreditAccountInBank(Bank bank, Client client, float sum);

        void RewindTime(int days);

        void ChangeCreditLimit(Bank bank, float newLimit);
        void ChangePercent(Bank bank, float newPercent);

        void Subscribe(Bank bank, Client client);

        void RefillCash(Bank bank, Client client, Account account, float sum);
        void WithdrawalCash(Bank bank, Client client, Account account, float sum);
        void Transfer(Bank bank, Client client1, Client client2, Account account1, Account account2, float sum);
        void CancelTransaction(Account account);
    }
}