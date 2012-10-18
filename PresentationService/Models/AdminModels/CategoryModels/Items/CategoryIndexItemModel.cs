using System;
using System.Collections.Generic;
using System.Linq;
using DomainService.DomainModels;

namespace PresentationService.Models.AdminModels.CategoryModels.Items
{
    public class CategoryIndexItemModel
    {
        public CategoryIndexItemModel(Category category)
        {
            if (category == null)
            {
                throw new ArgumentNullException("category");
            }

            CategoryId = category.Id;
            CategoryName = category.Name;

            if (category.ChildCategories != null)
            {
                Subcategories = category.ChildCategories.Select(c => new CategoryIndexItemModel(c));
            }
        }

        public string CategoryName { get; private set; }

        public long CategoryId { get; private set; }

        public IEnumerable<CategoryIndexItemModel> Subcategories { get; private set; }
    }
}