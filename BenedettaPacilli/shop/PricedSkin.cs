using System.Drawing;
using Utilities;

namespace ShopSpace
{
    /// <summary>
    /// A class that extends Skin class and shapes a Skin object equipped with a
    /// price field
    /// </summary>
    public class PricedSkin : Skin
    {
        private int price;
    
        /// <summary>
        /// Gets and sets the priced field
        /// </summary>
        public int Price { get => price; set => price = value; }

        /// <param name="name"> the Skin name</param>
        /// <param name="image"> the Image to show the object</param>
        /// <param name="width"> the Skin width</param>
        /// <param name="height"> the Skin height</param>
        /// <param name="price"> the PricedSkin price</param>
        public PricedSkin(string name, Image image, int width, int height, int price):base(name, image, width, height)
        {
            Price = price;
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            return obj is PricedSkin skin &&
                   base.Equals(obj) &&
                   Price == skin.Price;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}