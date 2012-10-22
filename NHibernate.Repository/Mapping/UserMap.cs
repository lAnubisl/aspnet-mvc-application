using DomainService.DomainModels;
using DomainService.Enumerations;
using FluentNHibernate.Mapping;

namespace NHibernate.Repository.Mapping
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(x => x.Id).Column("UserId");
            Map(x => x.FirstName).Nullable();
            Map(x => x.LastName).Nullable();
            Map(x => x.Email).Not.Nullable();
            Map(x => x.Role).Not.Nullable().Column("RoleId").CustomType<Role>();
        }
    }
}