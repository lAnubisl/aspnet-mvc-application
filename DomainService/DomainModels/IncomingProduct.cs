namespace DomainService.DomainModels
{
    public class IncomingProduct : DomainObject
    {
        public virtual Product Product { get; set; }

        public virtual long Count { get; set; }

        public virtual Consignment Consignment { get; set; }

        public override int GetHashCode()
        {
            return string.Concat(GetType().FullName, Count, Consignment.GetHashCode()).GetHashCode();
        }
    }
}