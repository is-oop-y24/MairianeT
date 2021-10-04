using System;

namespace Shops.Entities
{
    public class Customer
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
                throw new Exception("Not enough money on balance");
            }
        }

        public bool IsBuyProduct(Product product, Shop shop, int number)
        {
            if (_balance >= product.Price() * number)
            {
                return shop.IsBuyABatch(product, number);
            }

            return false;
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
