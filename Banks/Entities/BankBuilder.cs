using System.Collections.Generic;

namespace Banks.Entities
{
    public class BankBuilder
    {
        private string _name;
        private float _percent;
        private float _commission;
        private float _creditLimit;
        private float _unverifiedLimit;
        private List<float> _interests = new List<float>();

        public BankBuilder SetName(string name)
        {
            _name = name;
            return this;
        }

        public BankBuilder SetPercent(float percent)
        {
            _percent = percent;
            return this;
        }

        public BankBuilder SetCommission(float commission)
        {
            _commission = commission;
            return this;
        }

        public BankBuilder SetCreditLimit(float creditLimit)
        {
            _creditLimit = creditLimit;
            return this;
        }

        public BankBuilder SetInterests(float lowInterest, float averageInterest, float hightInterest)
        {
            _interests.Add(lowInterest);
            _interests.Add(averageInterest);
            _interests.Add(hightInterest);
            return this;
        }

        public BankBuilder SetUnverifiedLimit(float unverifiedLimit)
        {
            _unverifiedLimit = unverifiedLimit;
            return this;
        }

        public Bank GetBank() => new Bank(_name, _percent, _commission, _creditLimit, _unverifiedLimit, _interests);
    }
}