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
            Map(x => x.IsUnlimitedProduct);
            References(x => x.Category).Not.Nullable().Column("CategoryId");
            References(x => x.CreatedBy).Not.Nullable().Column("UserId");
            HasManyToMany(x => x.Images).Table("ProductToImage").ParentKeyColumn("ProductId").ChildKeyColumn("ImageId").Cascade.All();
        }
    }
}