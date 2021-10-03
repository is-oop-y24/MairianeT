using System;
using Shops.Entities;

namespace Shops.Services
{
    public interface IShopManager
    {
        Shop AddShop(string name);
        Shop FindShop(int id);
        void RemoveShop(Shop shop);
    }
}