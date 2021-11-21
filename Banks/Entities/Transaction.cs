using System.Collections.Generic;

namespace Banks.Entities
{
    public class Transaction
    {
        public Transaction(string name, double sum, List<Account> accounts)
        {
            BankAccounts = accounts;
            Sum = sum;
            TranactionName = name;
        }

        public double Sum { get; }
        public string TranactionName { get; }
        public List<Account> BankAccounts { get; }

        public void CancelTransaction()
        {
            switch (TranactionName)
            {
                case "refill":
                    BankAccounts[0].CashWithdrawal(Sum);
                    break;
                case "withdrawal":
                    BankAccounts[0].Refill(Sum);
                    break;
                case "transfer":
                    BankAccounts[0].Refill(Sum);
                    BankAccounts[1].CashWithdrawal(Sum);
                    break;
            }
        }
    }
}