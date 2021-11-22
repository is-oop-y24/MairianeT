using System.Collections.Generic;

namespace Banks.Entities
{
    public class BankBuilder
    {
        private string _name;
        private double _percent;
        private double _commission;
        private double _creditLimit;
        private double _unverifiedLimit;
        private List<double> _interests = new List<double>();

        public BankBuilder SetName(string name)
        {
            _name = name;
            return this;
        }

        public BankBuilder SetPercent(double percent)
        {
            _percent = percent;
            return this;
        }

        public BankBuilder SetCommission(double commission)
        {
            _commission = commission;
            return this;
        }

        public BankBuilder SetCreditLimit(double creditLimit)
        {
            _creditLimit = creditLimit;
            return this;
        }

        public BankBuilder SetInterests(double lowInterest, double averageInterest, double highInterest)
        {
            _interests.Add(lowInterest);
            _interests.Add(averageInterest);
            _interests.Add(highInterest);
            return this;
        }

        public BankBuilder SetUnverifiedLimit(double unverifiedLimit)
        {
            _unverifiedLimit = unverifiedLimit;
            return this;
        }

        public Bank GetBank() => new Bank(_name, _percent, _commission, _creditLimit, _unverifiedLimit, _interests);
    }
}