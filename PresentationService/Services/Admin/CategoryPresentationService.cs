using System;
using DomainService.DomainModels;
using DomainService.DomainServiceInterfaces;
using PresentationService.Interfaces.Admin;
using PresentationService.Models.AdminModels.CategoryModels;

namespace PresentationService.Services.Admin
{
    public class CategoryPresentationService : ICategoryPresentationService
    {
        private readonly ICategoryDomainService categoryDomainService;

        public CategoryPresentationService(ICategoryDomainService categoryDomainService)
        {
            this.categoryDomainService = categoryDomainService;
        }

        public void SaveCategoryEditModel(CategoryEditModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("model");
            }

            var category = model.CategoryId != default(long)
                               ? categoryDomainService.Load(model.CategoryId)
                               : new Category();
            if (category != null)
            {
                category.Name = model.CategoryName;
                category.Description = model.CategoryDescription;
                category.SeoURL = model.SeoURL;
                category.ParentCategory = model.ParentCategoryId.HasValue 
                    ? categoryDomainService.Load(model.ParentCategoryId.Value) 
                    : null;

                categoryDomainService.Save(category);
            }
        }

        public bool CanBeDeleted(long categoryId)
        {
            return !categoryDomainService.HasChildCategories(categoryId) &&
                !categoryDomainService.HasProducts(categoryId);
        }

        public void DeleteCategory(long categoryId)
        {
            if (CanBeDeleted(categoryId))
            {
                 categoryDomainService.Delete(categoryId);
            }
        }

        public CategoryEditModel LoadCategoryEditModel(long categoryId)
        {
            var category = categoryId != default(long) 
                ? categoryDomainService.Load(categoryId) 
                : new Category();
            if (category != null)
            {
                var parentCategories = categoryDomainService.LoadDependencySaveParentsForCategoryId(categoryId);
                var canBeDeleted = CanBeDeleted(categoryId);
                return new CategoryEditModel(category, parentCategories, canBeDeleted);
            }

            return null;
        }

        public CategoryIndexModel LoadCategoryIndexModel()
        {
            return new CategoryIndexModel(categoryDomainService.LoadRootCategories());                  
        }       
    }
}