using System.Collections.Generic;
using System.Transactions;

namespace Banks.Entities
{
    public abstract class Account
    {
        public Account(double sum, Bank bank, int id)
        {
            Balance = sum;
            Percent = bank.BankPercent;
            Owner = bank;
            Id = id;
        }

        public int Id { get; }
        public Bank Owner { get; }
        public double Balance { get; protected set; }
        public double Percent { get; set; }
        public Transaction LastTransaction { get; set; }

        public void Refill(double sum)
        {
            Balance += sum;
            LastTransaction = new Transaction(TransactionType.Refill, sum, new List<Account> { this });
        }

        public virtual void CashWithdrawal(double sum)
        {
            if (!(Balance >= sum)) return;
            Balance -= sum;
            LastTransaction = new Transaction(TransactionType.Withdraw, sum, new List<Account> { this });
        }

        public void Transfer(double sum, Account account)
        {
            CashWithdrawal(sum);
            account.Refill(sum);
            LastTransaction = new Transaction(TransactionType.Transfer, sum, new List<Account> { this, account });
        }

        public virtual void RewindTime(int days)
        {
        }
    }
}