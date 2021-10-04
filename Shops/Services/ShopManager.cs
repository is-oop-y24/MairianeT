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
            var newShop = new Shop(name, address, shopsId);
            shopsId++;
            shops.Add(newShop);
            return newShop;
        }

        public Product AddProduct(string name, int price)
        {
            var newProduct = new Product(name, price);
            products.Add(newProduct);
            return newProduct;
        }

        public Shop FindShop(int id)
        {
            foreach (Shop shop in shops)
            {
                if (shop.AreEqual(id))
                {
                    return shop;
                }
            }

            return null;
        }

        public void AddProductToShop(Product newProduct, int number)
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

        public void ProductPurchase(Customer customer, Product product, int number)
        {
            Shop shop = CheapestPurchase(product, number);
            if (shop != null)
            {
                customer.SpendMoney(shop.BatchCost(product, number));
                shop.IsBuyABatch(product, number);
            }
        }
    }
}