using System.Collections.Generic;
using Banks.Tools;

namespace Banks.Entities
{
    public class DepositAccount : Account
    {
        private int _term;
        private int _currentDate = 0;
        private int _date = 0;

        public DepositAccount(double sum, Bank bank, int term, int id)
        : base(sum, bank, id)
        {
            double curPercent;
            if (sum < 50000) curPercent = bank.DepositInterests[0];
            else if (sum < 100000) curPercent = bank.DepositInterests[1];
            else curPercent = bank.DepositInterests[2];

            Percent = curPercent;
            _term = term;
        }

        public override void CashWithdrawal(double sum)
        {
            if (_term <= _currentDate && Balance >= sum)
            {
                Balance -= sum;
            }
            else
            {
                throw new BanksException("You cannot withdraw money from this account");
            }

            LastTransaction = new Transaction(TransactionType.Withdraw, sum, new List<Account> { this });
        }

        public override void RewindTime(int days)
        {
            const int daysInYear = 365;
            double dayPercent = Percent / daysInYear;

            if (days + _date >= _term)
            {
                Balance = (_currentDate + _term - _date) * dayPercent * Balance;
                _date = _term;
            }
            else
            {
                _currentDate += days;
                _date += days;
                if (_currentDate > 30)
                {
                    Balance += Balance * _currentDate / 30 * dayPercent;
                }

                _currentDate = (days + _currentDate) % 30;
            }
        }
    }
}