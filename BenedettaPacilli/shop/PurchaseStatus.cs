namespace ShopSpace
{
    public class PurchaseStatus<X>
    {
        private X item;
        private bool purchased;

        public bool Purchased { get => purchased; set => purchased = value; }
            public X Item { get => item; set => item = value; }

            public PurchaseStatus(X item, bool purchased)
            {
                this.item = item;
                this.purchased = purchased;
            }
    }
}