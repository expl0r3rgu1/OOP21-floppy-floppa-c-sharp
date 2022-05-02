using System.Drawing;
using InfiniteMap;

namespace ShopSpace
{
    /// <summary>
    /// A class that extends Background class and shapes a Background object equipped
    /// with a price field
    /// </summary>
    public class PricedBackground : Background
    {
        private int price;

        /// <summary>
        /// Gets and sets the price field
        /// </summary>
        public int Price { get => price; set => price = value; }

        /// <param name="name"> The Background name</param>
        /// <param name="image"> The Background Image to show it</param>
        /// <param name="price"> The PricedBackground price</param>
        public PricedBackground(string name, Image image, int price) : base(name, image)
        {
            Price = price;
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            PricedBackground other = (PricedBackground)obj;
            return base.Equals(other) && Price == other.Price;
        }
    }
}