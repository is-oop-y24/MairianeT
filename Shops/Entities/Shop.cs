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
        private string _address;

        public Shop(string name, string address, int id)
        {
            _id = id;
            _name = name;
            _address = address;
        }

        public void AddProduct(Product newProduct)
        {
            Product resultProduct = null;
            foreach (Product product in products)
            {
                if (product.AreEqual(newProduct))
                {
                    resultProduct = product;
                    break;
                }
            }

            if (resultProduct != null)
            {
                resultProduct.IncreaseNumber(newProduct.Number());
            }
            else
            {
                products.Add(newProduct);
            }
        }

        public bool IsBuyABatch(Product product, int number)
        {
            int index = products.IndexOf(product);
            if (index < 0) return false;
            if (products[index].Number() < number) return false;
            products[index].DecreaseNumber(number);
            if (products[index].Number() != 0) return true;
            products.RemoveAt(index);

            return true;
        }

        public int BatchCost(Product product, int number)
        {
            int index = products.IndexOf(product);
            if (index < 0) return -1; // no product
            if (products[index].Number() < number) return -2; // not enough products
            int batchCost = number * products[index].Price();
            return batchCost;
        }

        public bool IsProductInShop(Product product)
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
            return product.Number();
        }

        public bool IsBuyProduct(Product product, Customer person, int number)
        {
            if (person.Balance() < product.Price() * number) return false;
            if (!IsBuyABatch(product, number)) return false;
            person.SpendMoney(product.Price() * number);
            return true;
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
