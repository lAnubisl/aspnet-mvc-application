namespace DomainService.DomainModels
{
    public class Image : DomainObject
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings", Justification = "This is a string property representation of database field")]
        public virtual string Url { get; set; }

        public override int GetHashCode()
        {
            return string.Concat(GetType().FullName, Url).GetHashCode();
        }
    }
}