using DomainService.DomainModels;
using DomainService.Enumerations;
using FluentNHibernate.Mapping;

namespace NHibernate.Repository.Mapping
{
    public class OrderMap : ClassMap<Order>
    {
        public OrderMap()
        {
            Id(x => x.Id).Column("OrderId");
            References(x => x.Customer).Column("UserId");
            Map(x => x.CreationDate);
            Map(x => x.Status).Not.Nullable().Column("OrderStatusId").CustomType<OrderStatus>();
            HasMany(x => x.OrderItems)
                .LazyLoad()
                .Inverse()
                .Cascade.AllDeleteOrphan()
                .KeyColumn("OrderId");
        }
    }
}