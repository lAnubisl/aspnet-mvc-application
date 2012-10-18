using DomainService.DomainModels;
using FluentNHibernate.Mapping;

namespace NHibernate.Repository.Mapping
{
    public class AvailableProductMap : SubclassMap<AvailableProduct>
    {
        public AvailableProductMap()
        {
            KeyColumn("ProductId");
            Map(m => m.Count).Not.Update();
        }
    }
}
