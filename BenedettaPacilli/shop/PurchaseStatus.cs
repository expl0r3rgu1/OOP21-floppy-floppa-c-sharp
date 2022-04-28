namespace Shop {
public class PurchaseStatus<X>
{
    private X x;
    private bool purchased;

    public X X { get => x; set => x = value; }

    public bool Purchased { get => purchased; set => purchased = value; }

}
}