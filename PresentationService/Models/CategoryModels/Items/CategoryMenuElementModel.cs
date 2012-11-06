using System;
using System.Collections.Generic;
using System.Linq;
using DomainService.DomainModels;

namespace PresentationService.Models.CategoryModels.Items
{
    public class CategoryMenuElementModel
    {
        public CategoryMenuElementModel(Category category, IEnumerable<Category> childCategories)
        {
            if (category == null)
            {
                throw new ArgumentNullException("category");
            }

            CategoryId = category.Id;
            CategoryName = category.Name;

            if (childCategories != null)
            {
                Subcategories = childCategories.Select(c => new CategoryMenuElementModel(c, null));
            }
        }

        public string CategoryName { get; private set; }

        public long CategoryId { get; private set; }

        public IEnumerable<CategoryMenuElementModel> Subcategories { get; private set; } 
    }
}