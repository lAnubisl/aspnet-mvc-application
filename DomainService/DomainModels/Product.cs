namespace DomainService.DomainModels
{
    public class Product : DomainObject
    {
        public virtual User CreatedBy { get; set; }

        public virtual Category Category { get; set; }

        public virtual float Price { get; set; }

        public virtual string Name { get; set; }

        public virtual string Description { get; set; }

        public override int GetHashCode()
        {
            return string.Concat(GetType().FullName, Name, Description, CreatedBy, Category).GetHashCode();
        }
    }
}