using System;

namespace Banks.Entities
{
    public class CreditAccount : Account
    {
        public CreditAccount(double sum, Bank bank, int id)
            : base(sum, bank, id)
        {
            CreditCommission = bank.BankCommission;
            Limit = bank.CreditLimit;
        }

        public double CreditCommission { get; set; }
        public double Limit { get; set; }

        public void ChangeLimit(double newLimit)
        {
            Limit = newLimit;
        }

        public override void RewindTime(int days)
        {
            if (Limit > Balance)
                Balance -= Balance * CreditCommission * days;
        }
    }
}