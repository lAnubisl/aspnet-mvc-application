namespace DomainService.DomainModels
{
    public class Image : DomainObject
    {
        public virtual string URL { get; set; }

        public override int GetHashCode()
        {
            return string.Concat(GetType().FullName, URL).GetHashCode();
        }
    }
}