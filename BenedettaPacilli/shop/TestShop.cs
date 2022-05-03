using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace ShopSpace
{
    [TestFixture]
    public class TestShop
    {
        private const int ENOUGH_COINS = 1000;
        private const int NOT_ENOUGH_COINS = 0;

        [Test]
        public void FileReading()
        {
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
    }
}
