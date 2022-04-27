using System.Drawing;

public class PricedBackground : Background
{
    private int _price;

    public int Price { get => _price; set => _price = value; }

    public PricedBackground(string name, Image image, int price) : base(name, image)
    {
        Price = price;
    }

    public override bool Equals(object obj)
    {
        PricedBackground other = (PricedBackground)obj;
        return base.Equals(other) & Price == other.Price;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}