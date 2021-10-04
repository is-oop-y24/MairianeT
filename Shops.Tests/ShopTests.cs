using NUnit.Framework;
using Shops.Entities;
using Shops.Services;

namespace Shops.Tests
{
    public class ShopTests
    {
        private IShopMeneger _shopMeneger;

        [SetUp]
        public void SetUp()
        {
            _shopMeneger = new IShopMeneger();
        }

        [Test]
        public void AddProductToShop_ShopHasProduct()
        {
            Shop shop = _shopMeneger.AddShop("Prisma", "Transport line, 4");
            int chocolatePrice = 50;
            Product product1 = _shopMeneger.AddProduct("chocolate", chocolatePrice);
            int chocolateNumber = 100;
            shop.AddProduct(product1, chocolateNumber);

            Assert.IsTrue(shop.IsProductInShop(product1));
        }

        public void ChangePrice()
        {
            Shop shop = _shopMeneger.AddShop("Prisma", "Transport line, 4");
            int chocolatePrice = 50;
            Product product1 = _shopMeneger.AddProduct("chocolate", chocolatePrice);
            int chocolateNumber = 100;
            shop.AddProduct(product1, chocolateNumber);
            
            Assert.AreEqual(chocolatePrice, shop.GetProduct().Price());
            
            int newChocolatePrice = 45;
            shop.GetProduct(product1).ChangePrice(newChocolatePrice);
            
            Assert.AreEqual(newChocolatePrice, shop.GetProduct(product1).Price());
        }
    }
}