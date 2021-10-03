using System;
using Shops.Entities;

namespace Shops.Services
{
	public interface IShopManager
	{
        void AddShop(Shop shop);
        Shop FindShop(int id);
        void RemoveShop(Shop shop);

    }

}