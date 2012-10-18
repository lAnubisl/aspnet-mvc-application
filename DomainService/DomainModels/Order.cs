using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using DomainService.Enumerations;

namespace DomainService.DomainModels
{
    public class Order : DomainObject
    {
        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly", Justification = "This entire type is mutable because it is used by NHibernate.")]
        public virtual IList<OrderItem> OrderItems { get; set; }

        public virtual User Customer { get; set; }

        public virtual OrderStatus Status { get; set; }

        public virtual DateTime CreationDate { get; set; }

        public virtual void AddOrderItem(OrderItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            if (OrderItems == null)
            {
                OrderItems = new List<OrderItem>();
            }

            OrderItems.Add(item);
            item.Order = this;
        }

        public override int GetHashCode()
        {
            return string.Concat("Order", CreationDate, Status, Customer.GetHashCode()).GetHashCode();
        }
    }
}