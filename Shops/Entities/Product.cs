using System;
using System.Collections.Generic;

namespace Shops.Entities
{
    public class Product
    {
        private int _price;
        private string _name;

        public Product(string name, int price)
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
    }
}