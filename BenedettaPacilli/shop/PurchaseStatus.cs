namespace ShopSpace
{
    /// <summary>
    /// A class that keeps track of the current purchase status of an object X
    /// </summary>
    /// <typeparam name="X"></typeparam>
    public class PurchaseStatus<X>
    {
        private X item;
        private bool purchased;

        /// <summary>
        /// Returns true if the item has been purchased, false otherwise and
        /// can set if the item has been purchased or not.
        /// </summary>
        public bool Purchased { get => purchased; set => purchased = value; }
        
        /// <summary>
        /// Gets and sets the X field
        /// </summary>
        public X Item { get => item; set => item = value; }

        public PurchaseStatus(X item, bool purchased)
        {
            this.item = item;
            this.purchased = purchased;
        }
    }
}