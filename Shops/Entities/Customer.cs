using System;
using System.Collections.Generic;
using System.Text;

namespace Shops.Entities
{
    class Customer
    {
        private int _balance;
        private string _name;

        public Customer(string name, int balance)
        {
            _balance = balance;
            _name = name;
        }

        public int AddMoney(int money)
        {
            if (money > 0)
            {
                _balance += money;
            }
            return _balance;
        }

        public int SpendMoney(int money)
        {
            if (_balance >= money)
            {
                _balance -= money;
                return _balance;
            }
            else
            {
                return -1; //not enough money on balance
            }
        }

        public int Balance()
        {
            return _balance;
        }

        public string Name()
        {
            return _name;
        }
    }
}
