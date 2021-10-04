using System.Collections.Generic;
using Shops.Entities;

namespace Shops.Services
{
    public class ShopManager : IShopManager
    {
        private List<Shop> shops = new List<Shop>();
        private List<Product> products = new List<Product>();
        private int shopsId = 0;

        public ShopManager()
        {
        }

        public Shop AddShop(string name, string address)
        {
            var newShop = new Shop(name, address, shopsId++);
            shops.Add(newShop);
            return newShop;
        }

        public Product AddProduct(string name, int price)
        {
            var newProduct = new Product(name, price);
            products.Add(newProduct);
            return newProduct;
        }

        public void AddProductToShop(Product newProduct, int number, Shop shop)
        {
            shop.AddProduct(newProduct, number);
        }

        public void ProductPurchase(Customer customer, Product product, int number)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveShop(Shop shop)
        {
            shops.Remove(shop);
        }

        public Shop CheapestPurchase(Product product, int number)
        {
            int minCost = 1000000000;
            Shop cheapShop = null;
            foreach (Shop shop in shops)
            {
                if (shop.BatchCost(product, number) < minCost && shop.BatchCost(product, number) >= 0)
                {
                    minCost = shop.BatchCost(product, number);
                    cheapShop = shop;
                }
            }

            return cheapShop;
        }

        public bool IsProductPurchase(Customer person, Product product, Shop shop, int number)
        {
            return shop.IsBuyProduct(product, person, number);
        }

        public void AddProductToShop(Shop shop, Product product, int number)
        {
            shop.AddProduct(product, number);
        }
    }
}