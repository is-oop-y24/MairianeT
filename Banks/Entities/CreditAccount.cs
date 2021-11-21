using System;

namespace Banks.Entities
{
    public class CreditAccount : Account
    {
        public CreditAccount(float sum, Bank bank)
            : base(sum, bank)
        {
            CreditCommission = bank.BankCommission;
            Limit = bank.CreditLimit;
        }

        public float CreditCommission { get; set; }
        public float Limit { get; set; }

        public void ChangeLimit(float newLimit)
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