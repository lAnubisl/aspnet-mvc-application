using DomainService.DomainModels;
using FluentNHibernate.Mapping;

namespace NHibernate.Repository.Mapping
{
    public class OrderItemMap : ClassMap<OrderItem>
    {
        public OrderItemMap()
        {
            Id(x => x.Id).Column("OrderItemId");
            Map(x => x.Price);
            References(x => x.Product).Column("ProductId");
            References(x => x.Order).Column("OrderId");
        }
    }
}