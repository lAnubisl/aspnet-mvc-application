using System.Collections.Generic;
using System.Linq;
using DomainService.DomainModels;
using DomainService.DomainServiceInterfaces;
using DomainService.RepositoryInterfaces;

namespace DomainService.DomainServices
{
    public class CategoryDomainService : GenericDomainService<Category, ICategoryRepository>,
                                         ICategoryDomainService
    {
        #region ICategoryDomainService Members

        public bool IsUniqueName(long categoryId, string categoryName)
        {
            return !Repository.Query().Any(category => category.Name.Equals(categoryName) && category.Id != categoryId);
        }

        public IList<Category> LoadByParentCategoryId(long parentCategoryId)
        {
            return Repository.Query().Where(c => c.ParentCategory.Id == parentCategoryId).ToList();
        }

        public IList<Category> LoadRootCategories()
        {
            return Repository.Query().Where(c => c.ParentCategory == null).ToList();
        }

        public IList<Category> LoadDependencySaveParentsForCategoryId(long categoryId)
        {
            return Repository.LoadDependencySaveParentsForCategoryId(categoryId);
        }

        #endregion
    }
}