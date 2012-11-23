using DomainService.DomainModels;
using FluentNHibernate.Mapping;

namespace NHibernate.Repository.Mapping
{
    public class ImageMap : ClassMap<Image>
    {
        public ImageMap()
        {
            Id(x => x.Id).Column("ImageId");
            Map(x => x.Url);
        }
    }
}