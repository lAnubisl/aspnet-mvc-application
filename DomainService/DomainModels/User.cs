using System.Globalization;
using DomainService.Enumerations;

namespace DomainService.DomainModels
{
    public class User : DomainObject
    {
        public virtual string FirstName { get; set; }

        public virtual string LastName { get; set; }

        public virtual string Email { get; set; }

        public virtual Role Role { get; set; }

        public virtual string FullName
        {
            get
            {
                return string.Join(" ", FirstName, LastName);
            }
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0} {1}", FirstName, LastName);
        }

        public override int GetHashCode()
        {
            return string.Concat("User", FirstName, LastName, Email, Role).GetHashCode();
        }
    }
}