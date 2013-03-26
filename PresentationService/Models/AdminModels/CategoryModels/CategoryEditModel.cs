using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using DomainService.DomainModels;
using PresentationService.Models.AdminModels.CategoryModels.Items;
using PresentationService.Resources;
using PresentationService.ValidationAttributes;

namespace PresentationService.Models.AdminModels.CategoryModels
{
    public class CategoryEditModel
    {
        private readonly IEnumerable<CategorySelectListItemModel> parentCategoryModels;
        private readonly long categoryId;
        private readonly bool canBeDeleted;

        internal CategoryEditModel(Category category, IEnumerable<Category> parentCategories, bool canBeDeleted)
        {
            if (category == null)
            {
                throw new ArgumentNullException("category");
            }

            if (parentCategories == null)
            {
                throw new ArgumentNullException("parentCategories");
            }

            this.categoryId = category.Id;
            this.canBeDeleted = canBeDeleted;
            CategoryName = category.Name;
            CategoryDescription = category.Description;
            SeoURL = category.SeoURL;
            if (category.ParentCategory != null)
            {
                ParentCategoryId = category.ParentCategory.Id;
            }

            parentCategoryModels = parentCategories.Select(c => new CategorySelectListItemModel(c));
        }

        [Display(Name = "CategoryName", ResourceType = typeof(EntityNames)), CommonRequired, CommonStringLength(50), CategoryShouldHaveUniqueName]
        public string CategoryName { get; set; }

        [Display(Name = "CategoryDescription", ResourceType = typeof(EntityNames))]
        public string CategoryDescription { get; set; }

        public string SeoURL { get; set; }

        public long CategoryId
        { 
            get 
            { 
                return this.categoryId; 
            } 
        }

        public bool CanBeDeleted
        {
            get
            {
                return this.canBeDeleted;
            }
        }

        [Display(Name = "CategoryParent", ResourceType = typeof(EntityNames)), ParentShouldNotBeCurrentChild]
        public long? ParentCategoryId { get; set; }

        public IEnumerable<CategorySelectListItemModel> ParentCategories
        {
            get
            {
                return parentCategoryModels;
            }
        } 
    }
}