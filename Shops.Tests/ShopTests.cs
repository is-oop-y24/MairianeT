using NUnit.Framework;
using Shops.Entities;
using Shops.Services;

namespace Shops.Tests
{
    public class ShopTests
    {
        private IShopMeneger _shopManager;

        [SetUp]
        public void SetUp()
        {
            _shopManager = new IShopMeneger();
        }

        [Test]
        public void AddProductToShop_ShopHasProduct()
        {
            Shop shop = _shopManager.AddShop("Prisma", "Transport line, 4");
            int chocolatePrice = 50;
            Product product1 = _shopManager.AddProduct("chocolate", chocolatePrice);
            int chocolateNumber = 100;
            shop.AddProduct(product1, chocolateNumber);

            Assert.IsTrue(shop.IsProductInShop(product1));
        }

        public void ChangePrice()
        {
            Shop shop = _shopManager.AddShop("Prisma", "Transport line, 4");
            int chocolatePrice = 50;
            Product product1 = _shopManager.AddProduct("chocolate", chocolatePrice);
            int chocolateNumber = 100;
            shop.AddProduct(product1, chocolateNumber);
            
            Assert.AreEqual(chocolatePrice, shop.GetProduct().Price());
            
            int newChocolatePrice = 45;
            shop.GetProduct(product1).ChangePrice(newChocolatePrice);
            
            Assert.AreEqual(newChocolatePrice, shop.GetProduct(product1).Price());
        }

        public void FindCheapestShop()
        {
            Shop shop1 = _shopManager.AddShop("Prisma", "Transport line, 4");
            Shop shop2 = _shopManager.AddShop("Lenta", "Khasanskaya street, 17");
            Shop shop3 = _shopManager.AddShop("24h", "Khasanskaya street, 14");
            int chocolatePrice1 = 50;
            int chocolatePrice2 = 45;
            int chocolatePrice3 = 70;
            int standardPrice = 55;
            Product product = _shopManager.AddProduct("chocolate", standardPrice);
            Product product1 = _shopManager.AddProduct("chocolate", chocolatePrice1);
            Product product2 = _shopManager.AddProduct("chocolate", chocolatePrice2);
            Product product3 = _shopManager.AddProduct("chocolate", chocolatePrice3);
            int chocolateNumber = 100;
            shop1.AddProduct(product1, chocolateNumber);
            shop2.AddProduct(product2, chocolateNumber);
            shop3.AddProduct(product3, chocolateNumber);
            int requiredNumber = 34;
            Shop resultShop = _shopManager.CheapestPurchase(product, requiredNumber);
            
            Assert.AreEqual(shop1, resultShop);
        }

        public void Sopping()
        {
            Shop shop = _shopManager.AddShop("Prisma", "Transport line, 4");
            int chocolatePrice = 50;
            Product product1 = _shopManager.AddProduct("chocolate", chocolatePrice);
            int startChocolateNumber = 100;
            shop.AddProduct(product1, startChocolateNumber);
            int startBalance = 500;
            Customer person = new Customer("Ivan", startBalance);
            int chocolateNumber = 5;
            
            Assert.IsTrue(person.IsBuyProduct(product1, shop, chocolateNumber)); // enough money, enough number
            chocolateNumber = 20;
            Assert.IsFalse(person.IsBuyProduct(product1, shop, chocolateNumber)); // not enough money, enough number
            int newMoney = 5000;
            person.AddMoney(newMoney);
            chocolateNumber = 120;
            Assert.IsFalse(person.IsBuyProduct(product1, shop, chocolateNumber)); // enough money, not enough number

            chocolateNumber = 10;
            _shopManager.ProductPurchase(person, product1, shop, chocolateNumber);
            
            Assert.AreEqual(startBalance + newMoney - chocolateNumber * chocolatePrice, person.Balance());
            Assert.AreEqual(startChocolateNumber - chocolateNumber, shop.ProductNumber(product1));
        }
    }
}