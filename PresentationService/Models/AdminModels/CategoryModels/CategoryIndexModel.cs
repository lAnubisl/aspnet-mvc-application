using System;
using System.Collections.Generic;
using System.Linq;
using DomainService.DomainModels;
using PresentationService.Models.AdminModels.CategoryModels.Items;

namespace PresentationService.Models.AdminModels.CategoryModels
{
    public class CategoryIndexModel
    {
        private readonly IEnumerable<CategoryIndexItemModel> categories;

        internal CategoryIndexModel(IEnumerable<Category> rootCategories)
        {
            if (rootCategories == null)
            {
                throw new ArgumentNullException("rootCategories");
            }

            this.categories = rootCategories.Select(c => new CategoryIndexItemModel(c));
        }

        public IEnumerable<CategoryIndexItemModel> Categories
        {
            get
            {
                return this.categories;
            }
        }
    }
}