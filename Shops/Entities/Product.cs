using System;
using System.Collections.Generic;

namespace Shops.Entities
{
    public class Product
    {
        private int _price;
        private string _name;
        private int _number;

        public Product(string name, int price, int number)
        {
            if (price < 0)
            {
                throw new Exception("Invalid product price");
            }
            else
            {
                _price = price;
            }

            _name = name;
            _number = number;
        }

        public bool AreEqual(Product product)
        {
            if (_name == product.Name())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ChangePrice(int newPrice)
        {
            if (newPrice >= 0)
            {
                _price = newPrice;
            }
            else
            {
                throw new Exception("Invalid product price");
            }
        }

        public int Price()
        {
            return _price;
        }

        public string Name()
        {
            return _name;
        }

        public int Number()
        {
            return _number;
        }

        public void IncreaseNumber(int number)
        {
            _number += number;
        }

        public void DecreaseNumber(int number)
        {
            _number -= number;
        }
    }
}