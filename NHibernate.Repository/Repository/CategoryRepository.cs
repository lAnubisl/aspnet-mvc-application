using System.Collections.Generic;
using DomainService.DomainModels;
using DomainService.RepositoryInterfaces;

namespace NHibernate.Repository.Repository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(string connectionString) : base(connectionString)
        {
        }

        public IList<Category> LoadDependencySaveParentsForCategoryId(long categoryId)
        {
            //// Run stored procedure
            return NHibernateSession.CreateSQLQuery("exec parent_categories_for_categoryId ?")
                .AddEntity(typeof(Category)).SetInt64(0, categoryId).List<Category>();
            //// AddEntity tells NHhibernate that query result must be converted to Category entity
        }
    }
}