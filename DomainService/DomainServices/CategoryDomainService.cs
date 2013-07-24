﻿using System.Collections.Generic;
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

        public CategoryDomainService(ICategoryRepository repository) : base(repository)
        {
        }

        public bool HasChildCategories(long categoryId)
        {
            return Repository.Query().Any(category => category.ParentCategory.Id == categoryId);
        }

        public bool HasProducts(long categoryId)
        {
            return Repository.Query<Product>().Any(product => product.Category.Id == categoryId);
        }

        public bool IsUniqueName(long categoryId, string categoryName)
        {
            return !Repository.Query().Any(category => category.Name.Equals(categoryName) && category.Id != categoryId);
        }

        public IList<Category> LoadByParentCategoryId(long parentCategoryId)
        {
            return Repository.Query().Where(c => c.ParentCategory.Id == parentCategoryId).ToList();
        }

        public Category LoadBySeoURL(string seoURL)
        {
            return Repository.Query().SingleOrDefault(c => c.SeoURL == seoURL);
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