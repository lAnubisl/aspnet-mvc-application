using DomainService.DomainModels;
using FluentNHibernate.Mapping;

namespace NHibernate.Repository.Mapping
{
    public class RegisteredUserMap : SubclassMap<RegisteredUser>
    {
        public RegisteredUserMap()
        {
            KeyColumn("RegisteredUserId");
            Map(m => m.Password);
        }
    }
}
