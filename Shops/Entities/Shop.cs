using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Shops.Entities
{
    public class Shop
    {
        private int _id;
        private string _name;
        private List<Product> products = new List<Product>();
        private List<int> numbers = new List<int>();
        private string _address;

        public Shop(string name, string address, int id)
        {
            _id = id;
            _name = name;
            _address = address;
        }

        public bool AreEqual(int id)
        {
            throw new NotImplementedException();
        }

        public void AddProduct(Product newProduct, int number)
        {
            int index = -1;
            foreach (Product product in products)
            {
                if (product.AreEqual(newProduct))
                {
                    index = products.IndexOf(product);
                }
            }

            if (index > -1)
            {
                numbers[index] += number;
            }
            else
            {
                products.Add(newProduct);
                numbers.Add(number);
            }
        }

        public void BuyABatch(Product product, int number)
        {
            int index = products.IndexOf(product);
            if (index >= 0)
            {
                if (numbers[index] >= number)
                {
                    numbers[index] -= number;
                    if (numbers[index] == 0)
                    {
                        numbers.RemoveAt(index);
                        products.RemoveAt(index);
                    }
                }
            }
        }

        public int BatchCost(Product product, int number)
        {
            int index = products.IndexOf(product);
            if (index < 0) return -1; // no product
            if (numbers[index] < number) return -2; // not enough products
            int batchCost = number * products[index].Price();
            return batchCost;
        }

        public bool isProductInShop(Product product)
        {
            foreach (Product curProduct in products)
            {
                if (product.AreEqual(curProduct))
                {
                    return true;
                }
            }

            return false;
        }

        public Product GetProduct(string name)
        {
            foreach (Product product in products)
            {
                if (product.Name() == name)
                {
                    return product;
                }
            }

            return null;
        }

        public int ProductNumber(Product product)
        {
            int index = products.IndexOf(product);
            return numbers[index];
        }

        public int Id()
        {
            return _id;
        }

        public string Address()
        {
            return _address;
        }
    }
}
