namespace Shop {
public class PricedSkin : Skin
{
    private int _price;
    
    public int Price { get => _price; set => _price = value; }

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