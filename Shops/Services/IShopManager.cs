using System;
using Shops.Entities;

namespace Shops.Services
{
    public interface IShopManager
    {
        Shop AddShop(string name, string address);
        Product AddProduct(string name, int price, int number);
        Shop CheapestPurchase(Product product, int number);
        bool IsProductPurchase(Customer person, Product product, Shop shop, int number);
        void AddProductToShop(Product newProduct, Shop shop);
    }
}