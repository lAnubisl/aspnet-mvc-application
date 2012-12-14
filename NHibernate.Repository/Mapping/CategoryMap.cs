using DomainService.DomainModels;
using FluentNHibernate.Mapping;

namespace NHibernate.Repository.Mapping
{
    public class CategoryMap : ClassMap<Category>
    {
        public CategoryMap()
        {
            Id(x => x.Id).Column("CategoryId");
            Map(x => x.Name);
            Map(x => x.Description);
            Map(x => x.SeoURL);
            References(x => x.ParentCategory).Column("ParentCategoryId");
            HasMany(x => x.ChildCategories).KeyColumn("ParentCategoryId");
        }
    }
}