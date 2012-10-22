﻿using DomainService.DomainServiceInterfaces;
using PresentationService.Interfaces;
using PresentationService.Models.CategoryModels;

namespace PresentationService.Services
{
    public class CategoryPresentationService : ICategoryPresentationService
    {
        private readonly IAvailableProductDomainService productDomainService;
        private readonly ICategoryDomainService categoryDomainService;

        public CategoryPresentationService(IAvailableProductDomainService productDomainService, ICategoryDomainService categoryDomainService)
        {
            this.productDomainService = productDomainService;
            this.categoryDomainService = categoryDomainService;
        }

        public CategoryViewModel LoadCategoryViewModel(long categoryId)
        {
            var category = categoryDomainService.Load(categoryId);
            if (category != null)
            {
                return new CategoryViewModel(category, productDomainService.LoadByCategoryId(categoryId));
            }

            return null;
        }

        public CategoryMenuModel LoadCategoryMenuModel()
        {
            return new CategoryMenuModel(categoryDomainService.LoadRootCategories());
        }
    }
}