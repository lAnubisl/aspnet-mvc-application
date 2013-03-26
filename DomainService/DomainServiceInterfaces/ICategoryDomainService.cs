using System.Collections.Generic;
using DomainService.DomainModels;

namespace DomainService.DomainServiceInterfaces
{
    public interface ICategoryDomainService : IGenericDomainService<Category>
    {
        bool IsUniqueName(long categoryId, string categoryName);

        /// <summary>
        /// Load categories assigned to parent category
        /// </summary>
        /// <param name="parentCategoryId"></param>
        /// <returns></returns>
        IList<Category> LoadByParentCategoryId(long parentCategoryId);

        Category LoadBySeoURL(string seoURL);

        IList<Category> LoadRootCategories();

        IList<Category> LoadDependencySaveParentsForCategoryId(long categoryId);

        bool HasChildCategories(long categoryId);

        bool HasProducts(long categoryId);
    }
}