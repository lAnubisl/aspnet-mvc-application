using DomainService.DomainModels;
using DomainService.Enumerations;
using FluentNHibernate.Mapping;

namespace NHibernate.Repository.Mapping
{
    public class ConsignmentMap : ClassMap<Consignment>
    {
        public ConsignmentMap()
        {
            Id(x => x.Id).Column("ConsignmentId");
            References(x => x.User).Column("UserId");
            Map(x => x.CreationDate);
            Map(x => x.Status).Column("ConsignmentStatusId").CustomType<ConsignmentStatus>();
            HasMany(x => x.IncomingProducts)
                .LazyLoad()
                .Inverse()
                .Cascade.AllDeleteOrphan()
                .KeyColumn("ConsignmentId");
        }
    }
}
