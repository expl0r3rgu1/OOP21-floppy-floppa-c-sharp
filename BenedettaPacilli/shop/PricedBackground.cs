using System.Drawing;
using InfiniteMap;

namespace ShopSpace
{
    public class PricedBackground : Background
    {
        private int price;

        public int Price { get => price; set => price = value; }

        public PricedBackground(string name, Image image, int price) : base(name, image)
        {
            Price = price;
        }

        public bool Equals(object obj)
        {
            PricedBackground other = (PricedBackground)obj;
            return base.Equals(other) && Price == other.Price;
        }
    }
}