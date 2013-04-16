using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using DomainService.Enumerations;

namespace DomainService.DomainModels
{
    public class Consignment : DomainObject
    {
        public virtual User User { get; set; }

        public virtual DateTime CreationDate { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly", Justification = "This entire type is mutable because it is used by NHibernate.")]
        public virtual IList<IncomingProduct> IncomingProducts { get; set; }

        public virtual ConsignmentStatus Status { get; set; }

        public virtual void AddIncomingProduct(IncomingProduct incomingProduct)
        {
            if (incomingProduct != null)
            {
                incomingProduct.Consignment = this;
                this.IncomingProducts.Add(incomingProduct);
            }
        }

        public virtual void RemoveIncomingProduct(IncomingProduct incomingProduct)
        {
            if (incomingProduct != null && this.IncomingProducts != null && this.IncomingProducts.Contains(incomingProduct))
            {
                this.IncomingProducts.Remove(incomingProduct);
                incomingProduct.Consignment = null;
            }
        }

        public override int GetHashCode()
        {
            return string.Concat(GetType().FullName, User.GetHashCode(), CreationDate.GetHashCode()).GetHashCode();
        }
    }
}