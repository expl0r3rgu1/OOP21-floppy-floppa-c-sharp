using System.Drawing;

public class PricedBackground : Background
{
    private int _price;

    public PricedBackground(string name, Image image, int price) : base(name, image)
    {
        _price = price;
    }
}