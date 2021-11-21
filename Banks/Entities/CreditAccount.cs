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

        public float CreditCommission { get; }
        public float Limit { get; }
    }
}