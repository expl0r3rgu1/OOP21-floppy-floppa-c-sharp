using System.Drawing;

namespace ShopSpace
{
public class PricedSkin : Skin
{
    private int price;
    
    public int Price { get => price; set => price = value; }

    public PricedSkin(string name, Image image, int width, int height, int price):base(name, image, width, height)
    {
        Price = price;
    }

    public override bool Equals(object obj)
    {
        PricedSkin other = (PricedSkin)obj;
        return base.Equals(other) && Price == other.Price;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
}