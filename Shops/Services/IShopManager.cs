using System;
using Shops.Entities;

namespace Shops.Services
{
    public interface IShopManager
    {
        Shop AddShop(string name, string address);
        Product AddProduct(string name, int price);
        Shop FindShop(int id);
        Shop CheapestPurchase(Product product, int number);
        void ProductPurchase(Customer customer, Product product, int number);
        void RemoveShop(Shop shop);
    }
}