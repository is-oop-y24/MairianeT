using System.Collections.Generic;

namespace Banks.Entities
{
    public class Transaction
    {
        public Transaction(TransactionType transactionType, double sum, List<Account> accounts)
        {
            BankAccounts = accounts;
            Sum = sum;
            Type = transactionType;
        }

        public double Sum { get; }
        public TransactionType Type { get; }
        public List<Account> BankAccounts { get; }

        public void CancelTransaction()
        {
            switch (Type)
            {
                case TransactionType.Refill:
                    BankAccounts[0].CashWithdrawal(Sum);
                    break;
                case TransactionType.Withdraw:
                    BankAccounts[0].Refill(Sum);
                    break;
                case TransactionType.Transfer:
                    BankAccounts[0].Refill(Sum);
                    BankAccounts[1].CashWithdrawal(Sum);
                    break;
            }
        }
    }
}