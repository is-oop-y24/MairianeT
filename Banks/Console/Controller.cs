using System.Linq;
using Banks.Entities;
using Banks.Services;

namespace Banks.Console
{
    public class Controller
    {
        private ICentralBank _centralBank = new CentralBank();

        public void CreateBank(BankBuilder builder)
        {
            _centralBank.NewBank(builder);
        }

        public void RegisterClient(ClientBuilder builder)
        {
            _centralBank.NewClient(builder);
        }

        public void ChangePersent(int bankNumber, double newPersent)
        {
            _centralBank.ChangePercent(_centralBank.GetBanks()[bankNumber], newPersent);
        }

        public void ChangeCreditLimit(int bankNumber, double newLimit)
        {
            _centralBank.ChangeCreditLimit(_centralBank.GetBanks()[bankNumber], newLimit);
        }

        public string ShowBanks()
        {
            string answer = "Banks: \n";
            for (int i = 0; i < _centralBank.GetBanks().Count; i++)
            {
                answer = answer + (i + 1) + " " + _centralBank.GetBanks()[i].Name + "\n";
            }

            return answer;
        }

        public string BankInfo(int bankNumber)
        {
            Bank curBank = _centralBank.GetBanks()[bankNumber];
            return "Bank name: " + curBank.Name + " \n Percent: "
                          + (curBank.BankPercent * 100) + "% \n Commission: "
                          + (curBank.BankCommission * 100) + "% \n Credit limit: "
                          + curBank.CreditLimit + "rub \n Unverified limit: "
                          + curBank.UnverifiedLimit + " \n Deposit interests: \n < 50000 "
                          + (curBank.DepositInterests[0] * 100) + "% \n >= 50000 and < 100000 "
                          + (curBank.DepositInterests[1] * 100) + "% \n >= 100000 "
                          + (curBank.DepositInterests[2] * 100) + "% \n End of bank info.";
        }

        public void OpenDepositAccount(int bankNumber, string clientSurname, double sum, int term)
        {
            Client current = ReturnClient(clientSurname);

            if (current != null) _centralBank.NewDepositAccountInBank(_centralBank.GetBanks()[bankNumber], current, sum, term);
        }

        public void OpenCreditAccount(int bankNumber, string clientSurname, double sum)
        {
            Client current = ReturnClient(clientSurname);

            if (current != null) _centralBank.NewCreditAccountInBank(_centralBank.GetBanks()[bankNumber], current, sum);
        }

        public void OpenDebitAccount(int bankNumber, string clientSurname, double sum)
        {
            Client current = ReturnClient(clientSurname);

            if (current != null) _centralBank.NewDebitAccountInBank(_centralBank.GetBanks()[bankNumber], current, sum);
        }

        public string ShowAccountsForClient(string clientSurname)
        {
            string result = "Accounts: \n";
            Client current = ReturnClient(clientSurname);

            int i = 1;
            if (current == null) return null;
            foreach (Account account in _centralBank.GetBanks().SelectMany(bank => bank.ClientsAccounts[current]))
            {
                result = result + i + ". " + account.Id + "\n";
                i++;
            }

            return result;
        }

        public void RefillMoney(int bankNumber, string clientSurname, int accountId, double sum)
        {
            Client current = ReturnClient(clientSurname);
            Account account = ReturnAccount(accountId);
            _centralBank.RefillCash(_centralBank.GetBanks()[bankNumber], current, account, sum);
        }

        public Client ReturnClient(string clientSurname)
        {
            Client current = null;
            foreach (Client client in _centralBank.GetClients().Where(client => client.Surname == clientSurname))
            {
                current = client;
            }

            return current;
        }

        public Account ReturnAccount(int id)
        {
            return (from bank in _centralBank.GetBanks() from accounts in bank.ClientsAccounts.Values from account in accounts where account.Id == id select account).FirstOrDefault();
        }

        public void WithdrawMoney(int bankNumber, string clientSurname, int accountId, double sum)
        {
            Client current = ReturnClient(clientSurname);
            Account account = ReturnAccount(accountId);
            _centralBank.WithdrawalCash(_centralBank.GetBanks()[bankNumber], current, account, sum);
        }

        public void TransferMoney(int bankNumber, string client1Surname, string client2Surname, int account1Id, int account2Id, double sum)
        {
            Client client1 = ReturnClient(client1Surname);
            Client client2 = ReturnClient(client2Surname);
            Account account1 = ReturnAccount(account1Id);
            Account account2 = ReturnAccount(account2Id);
            _centralBank.Transfer(_centralBank.GetBanks()[bankNumber], client1, client2, account1, account2, sum);
        }

        public void CancelTransaction(int accountId)
        {
            _centralBank.CancelTransaction(ReturnAccount(accountId));
        }
    }
}