using NUnit.Framework;
using Shops.Entities;
using Shops.Services;

namespace Shops.Tests
{
    public class ShopTests
    {
        private IShopManager _shopManager;

        [SetUp]
        public void SetUp()
        {
            _shopManager = new ShopManager();
        }

        [Test]
        public void AddProductToShop_ShopHasProduct()
        {
            Shop shop = _shopManager.AddShop("Prisma", "Transport line, 4");
            int chocolatePrice = 50;
            int chocolateNumber = 100;
            Product product1 = _shopManager.AddProduct("chocolate", chocolatePrice, chocolateNumber);
            _shopManager.AddProductToShop(product1, shop);

            Assert.IsTrue(shop.IsProductInShop(product1));
        }

        public void ChangePrice()
        {
            Shop shop = _shopManager.AddShop("Prisma", "Transport line, 4");
            int chocolatePrice = 50;
            int chocolateNumber = 100;
            Product product1 = _shopManager.AddProduct("chocolate", chocolatePrice, chocolateNumber);
            _shopManager.AddProductToShop(product1, shop);
            
            Assert.AreEqual(chocolatePrice, shop.GetProduct(product1.Name()).Price());
            
            int newChocolatePrice = 45;
            shop.GetProduct(product1.Name()).ChangePrice(newChocolatePrice);
            
            Assert.AreEqual(newChocolatePrice, shop.GetProduct(product1.Name()).Price());
        }

        public void FindCheapestShop()
        {
            Shop shop1 = _shopManager.AddShop("Prisma", "Transport line, 4");
            Shop shop2 = _shopManager.AddShop("Lenta", "Khasanskaya street, 17");
            Shop shop3 = _shopManager.AddShop("24h", "Khasanskaya street, 14");
            const int chocolatePrice1 = 50;
            const int chocolatePrice2 = 45;
            const int chocolatePrice3 = 70;
            const int standardPrice = 55;
            const int chocolateNumber = 100;
            Product product = _shopManager.AddProduct("chocolate", standardPrice, chocolateNumber);
            Product product1 = _shopManager.AddProduct("chocolate", chocolatePrice1, chocolateNumber);
            Product product2 = _shopManager.AddProduct("chocolate", chocolatePrice2, chocolateNumber);
            Product product3 = _shopManager.AddProduct("chocolate", chocolatePrice3, chocolateNumber);
            _shopManager.AddProductToShop(product1, shop1);
            _shopManager.AddProductToShop(product2, shop2);
            _shopManager.AddProductToShop(product3, shop3);
            const int requiredNumber = 34;
            Shop resultShop = _shopManager.CheapestPurchase(product, requiredNumber);
            
            Assert.AreEqual(shop1, resultShop);
        }

        public void Sopping()
        {
            Shop shop = _shopManager.AddShop("Prisma", "Transport line, 4");
            const int chocolatePrice = 50;
            const int startChocolateNumber = 100;
            Product product1 = _shopManager.AddProduct("chocolate", chocolatePrice, startChocolateNumber);
            _shopManager.AddProductToShop(product1, shop);
            const int startBalance = 500;
            var person = new Customer("Ivan", startBalance);
            
            int chocolateNumber = 5;
            Assert.IsTrue(_shopManager.IsProductPurchase(person, product1, shop, chocolateNumber)); // enough money, enough number
            chocolateNumber = 20;
            Assert.IsFalse(_shopManager.IsProductPurchase(person, product1, shop, chocolateNumber)); // not enough money, enough number
            int newMoney = 5000;
            person.AddMoney(newMoney);
            chocolateNumber = 120;
            Assert.IsFalse(_shopManager.IsProductPurchase(person, product1, shop, chocolateNumber)); // enough money, not enough number

            chocolateNumber = 10;
            Assert.IsTrue(_shopManager.IsProductPurchase(person, product1, shop, chocolateNumber));
            
            Assert.AreEqual(startBalance + newMoney - chocolateNumber * chocolatePrice, person.Balance());
            Assert.AreEqual(startChocolateNumber - chocolateNumber, shop.ProductNumber(product1));
        }
    }
}