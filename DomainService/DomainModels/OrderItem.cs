namespace DomainService.DomainModels
{
    public class OrderItem : DomainObject
    {
        public virtual Product Product { get; set; }

        public virtual float Price { get; set; }

        public virtual Order Order { get; set; }

        public override int GetHashCode()
        {
            return string.Concat("OrderItem", Price, Product.GetHashCode(), Order.GetHashCode()).GetHashCode();
        }
    }
}