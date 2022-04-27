using System.Drawing;

public class PricedSkin : Skin
{
    private int _price;

    public PricedSkin(string name, Image image, int width, int height, int price):base(name, image, width, height)
    {
        _price = price;
    }

    public int GetPrice()
    {
        return _price;
    }

    public void SetPrice(int price)
    {
        _price = price;
    }

   public override bool Equals(object obj)
    {
        PricedSkin other = (PricedSkin)obj;
        return base.Equals(other) & _price == other._price;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}