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
}