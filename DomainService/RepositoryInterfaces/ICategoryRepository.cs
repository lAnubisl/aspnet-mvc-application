using System.Collections.Generic;
using DomainService.DomainModels;

namespace DomainService.RepositoryInterfaces
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        IList<Category> LoadDependencySaveParentsForCategoryId(long categoryId);
    }
}