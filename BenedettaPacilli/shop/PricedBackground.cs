using System.Drawing;

public class PricedBackground : Background
{
    private int _price;

    public PricedBackground(string name, Image image, int price) : base(name, image)
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
        PricedBackground other = (PricedBackground)obj;
        return base.Equals(other) & _price == other._price;
    }
}