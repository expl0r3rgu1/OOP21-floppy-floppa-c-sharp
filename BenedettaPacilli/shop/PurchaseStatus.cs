public class PurchaseStatus<X>
{
    private X _x;
    private bool _purchased;

    public X X { get => _x; set => _x = value; }

    public bool Purchased { get => _purchased; set => _purchased = value; }

}