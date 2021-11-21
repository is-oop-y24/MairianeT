using System.Collections.Generic;
using System.Transactions;

namespace Banks.Entities
{
    public class Account
    {
        public Account(float sum, Bank bank)
        {
            Balance = sum;
            Percent = bank.BankPercent;
            Owner = bank;
        }

        public Bank Owner { get; }
        public float Balance { get; protected set; }
        public float Percent { get; set; }
        public Transaction LastTransaction { get; set; }

        public void Refill(float sum)
        {
            Balance += sum;
            LastTransaction = new Transaction("refill", sum, new List<Account> { this });
        }

        public virtual void CashWithdrawal(float sum)
        {
            if (!(Balance >= sum)) return;
            Balance -= sum;
            LastTransaction = new Transaction("withdrawal", sum, new List<Account> { this });
        }

        public void Transfer(float sum, Account account)
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