using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace DomainService.DomainModels
{
    public class Category : DomainObject
    {
        public virtual Category ParentCategory { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly", Justification = "This entire type is mutable because it is used by NHibernate.")]
        public virtual IList<Category> ChildCategories { get; set; }

        public virtual string Name { get; set; }

        public virtual string Description { get; set; }

        public virtual string SeoURL { get; set; }

        public override int GetHashCode()
        {
            return string.Concat("Category", Name, ParentCategory, Description).GetHashCode();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}