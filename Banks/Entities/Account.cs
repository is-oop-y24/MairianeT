using System.Collections.Generic;
using System.Transactions;

namespace Banks.Entities
{
    public class Account
    {
        public Account(double sum, Bank bank)
        {
            Balance = sum;
            Percent = bank.BankPercent;
            Owner = bank;
        }

        public Bank Owner { get; }
        public double Balance { get; protected set; }
        public double Percent { get; set; }
        public Transaction LastTransaction { get; set; }

        public void Refill(double sum)
        {
            Balance += sum;
            LastTransaction = new Transaction("refill", sum, new List<Account> { this });
        }

        public virtual void CashWithdrawal(double sum)
        {
            if (!(Balance >= sum)) return;
            Balance -= sum;
            LastTransaction = new Transaction("withdrawal", sum, new List<Account> { this });
        }

        public void Transfer(double sum, Account account)
        {
            CashWithdrawal(sum);
            account.Refill(sum);
            LastTransaction = new Transaction("transfer", sum, new List<Account> { this, account });
        }

        public virtual void RewindTime(int days)
        {
        }
    }
}