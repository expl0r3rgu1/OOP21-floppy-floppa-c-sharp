namespace ShopSpace
{
public class PurchaseStatus<X>
{
    private X x;
    private bool purchased;

    public X X { get => x; set => x = value; }

    public bool Purchased { get => purchased; set => purchased = value; }

    public PurchaseStatus(X x, bool purchased)
        {
            this.x = x;
            this.purchased = purchased;
        }
}
}