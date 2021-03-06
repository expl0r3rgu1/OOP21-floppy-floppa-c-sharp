using System;
using System.IO;
using System.Collections.Generic;
using NUnit.Framework;

namespace ShopSpace
{
    [TestFixture]
    public class TestShop
    {
        private const int enoughCoins = 1000;
        private const int notEnoughCoins = 0;
        private const string savingsFileName = "savings";
        private const string savingsFileStartContent = "0\n1,0,0,0,0\n1,0,0,0,0";

        /// <summary>
        /// Checks if the Shop correctly reads info from the savings file. 
        /// </summary>
        [Test]
        public void FileReading()
        {
            CreateSavingsFile();
            Shop shop = new Shop();

            for(int i = 0; i < shop.SkinsNum; i++)
            {
                if (i == 0)
                {
                    Assert.IsTrue(shop.Skins[i].Purchased);
                } else
                {
                    Assert.IsFalse(shop.Skins[i].Purchased);
                }
            }

            for (int i = 0; i < shop.SceneriesNum; i++)
            {
                if (i == 0)
                {
                    Assert.IsTrue(shop.Sceneries[i].Purchased);
                } else
                {
                    Assert.IsFalse(shop.Sceneries[i].Purchased);
                }
            }
        }

        /// <summary>
        /// Checks if the Shop correctly buys items
        /// </summary>
        [Test]
        public void Buying()
        {
            this.CreateSavingsFile();
            Shop shop = new Shop();

            shop.Coins = notEnoughCoins;
            for (int i = 1; i < shop.SkinsNum; i++)
            {
                shop.Buy(shop.Skins[i].Item);
                Assert.IsFalse(shop.Skins[i].Purchased);
            }
            for (int i = 1; i < shop.SceneriesNum; i++)
            {
                shop.Buy(shop.Sceneries[i].Item);
                Assert.IsFalse(shop.Sceneries[i].Purchased);
            }

            shop.Coins = enoughCoins;
            int prevCoins = shop.Coins;
            for (int i = 1; i < shop.SkinsNum; i++)
            {
                shop.Buy(shop.Skins[i].Item);
                Assert.IsTrue(shop.Coins < prevCoins);
                prevCoins = shop.Coins;
                Assert.IsTrue(shop.Skins[i].Purchased);
            }

            shop.Coins = enoughCoins;
            prevCoins = shop.Coins;
            for (int i = 1; i < shop.SceneriesNum; i++)
            {
                shop.Buy(shop.Sceneries[i].Item);
                Assert.IsTrue(shop.Coins < prevCoins);
                prevCoins = shop.Coins;
                Assert.IsTrue(shop.Sceneries[i].Purchased);
            }
        }

        private void CreateSavingsFile()
        {
            StreamWriter sw = new StreamWriter(File.Create(savingsFileName));
            sw.WriteLine(savingsFileStartContent);
            sw.Close();
        }
    }
}
