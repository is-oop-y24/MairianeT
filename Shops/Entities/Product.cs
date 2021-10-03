using System;
using System.Collections.Generic;
using System.Text;

namespace Shops.Entities
{
    class Product
    {
        private int _price;
        private string _name;

        public Product(string name, int price)
        {
            if (price < 0) throw new Exception("Invalid product price");
            else
            {
                _price = price;
            }

            _name = name;
        }

        public bool AreEqual(Product product)
        {
            if (_name == product.Name)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}