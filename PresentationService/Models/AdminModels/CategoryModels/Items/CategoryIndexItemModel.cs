using System;
using System.Collections.Generic;
using System.Linq;
using DomainService.DomainModels;

namespace PresentationService.Models.AdminModels.CategoryModels.Items
{
    public class CategoryIndexItemModel
    {
        private readonly string categoryName;
        private readonly long categoryId;
        private readonly IEnumerable<CategoryIndexItemModel> subCategories;

        internal CategoryIndexItemModel(Category category)
        {
            if (category == null)
            {
                throw new ArgumentNullException("category");
            }

            this.categoryId = category.Id;
            this.categoryName = category.Name;

            if (category.ChildCategories != null)
            {
                this.subCategories = category.ChildCategories.Select(c => new CategoryIndexItemModel(c));
            }
        }

        public string CategoryName
        { 
            get 
            { 
                return this.categoryName; 
            } 
        }

        public long CategoryId
        { 
            get 
            { 
                return this.categoryId; 
            } 
        }

        public IEnumerable<CategoryIndexItemModel> Subcategories
        { 
            get 
            { 
                return this.subCategories; 
            } 
        }
    }
}