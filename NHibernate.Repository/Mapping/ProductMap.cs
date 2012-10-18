using DomainService.DomainModels;
using FluentNHibernate.Mapping;

namespace NHibernate.Repository.Mapping
{
    public class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            Id(x => x.Id).Column("ProductId");
            Map(x => x.Name).Not.Nullable();
            Map(x => x.Description).Not.Nullable();
            Map(x => x.Price).Not.Nullable();
            References(x => x.Category).Not.Nullable().Column("CategoryId");
            References(x => x.CreatedBy).Not.Nullable().Column("UserId");
        }
    }
}