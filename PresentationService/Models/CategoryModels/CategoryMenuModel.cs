using System;
using System.Collections.Generic;
using System.Linq;
using DomainService.DomainModels;
using PresentationService.Models.CategoryModels.Items;

namespace PresentationService.Models.CategoryModels
{
    public class CategoryMenuModel
    {
        public CategoryMenuModel(IEnumerable<Category> rootCategories)
        {
            if (rootCategories == null)
            {
                throw new ArgumentNullException("rootCategories");
            }

            RootCategories = rootCategories.Select(c => new CategoryMenuElementModel(c, c.ChildCategories));
        }

        public IEnumerable<CategoryMenuElementModel> RootCategories { get; private set; } 
    }
}
