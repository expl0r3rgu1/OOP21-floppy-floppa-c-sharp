public class PurchaseStatus<X>
{
    private X _x;
    private bool _purchased;

    public X GetX()
    {
        return _x;
    }

    public void SetX(int x)
    {
        _x = x;
    }

    public bool IsPurchased()
    {
        return _purchased;
    }

    public void Purchase()
    {
        _purchased = true;
    }

    public void ResetPurchase()
    {
        _purchased = false;
    }
}