using System;
using System.Collections.Generic;
using System.Text;
using Shops.Entities;

namespace Shops.Services
{
    class ShopManager
    {
        private List<Shop> shops = new List<Shop>;
        private List<Product> products = new List<Product>;

        public ShopManager()
        {
        }

        /*public void AddProduct(Product product)
        {
            if (!FindProduct(product.Name()))
            {
                products.Add(product);
            }
        }

        public Product FindProduct(string productName)
        {
            foreach (Product product in products)
            {
                if (product.AreEqual(productName))
                {
                    return product;
                }
            }
            return null;
        }

        public void RemoveProduct(Product product)
        {
            foreach (Product _product in products)
            {
                if (_product.AreEqual(product.Name())
                {
                    products.Remove(_product);
                }
            }
        }*/

        public void AddShop(Shop shop)
        {
            if (!FindShop(shop.ID()))
            {
                shops.Add(shop);
            }
        }

        public Shop FindShop(int id)
        {
            foreach (ShopManager shop in shops)
            {
                if (product.AreEqual(id))
                {
                    return shop;
                }
            }
            return null;
        }

        public void RemoveShop(Shop shop)
        {
            shops.Remove(shop);
        }

    }
}