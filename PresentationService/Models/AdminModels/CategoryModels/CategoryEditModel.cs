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

        public CategoryEditModel(Category category, IEnumerable<Category> parentCategories)
        {
            if (category == null)
            {
                throw new ArgumentNullException("category");
            }

            if (parentCategories == null)
            {
                throw new ArgumentNullException("parentCategories");
            }

            CategoryId = category.Id;
            CategoryName = category.Name;
            CategoryDescription = category.Description;
            SeoURL = category.SeoURL;
            parentCategoryModels = parentCategories.Select(c => new CategorySelectListItemModel(c));
        }

        [Display(Name = "CategoryName", ResourceType = typeof(EntityNames)), CommonRequired, CommonStringLength(50), CategoryShouldHaveUniqueName]
        public string CategoryName { get; set; }

        [Display(Name = "CategoryDescription", ResourceType = typeof(EntityNames))]
        public string CategoryDescription { get; set; }

        public string SeoURL { get; set; }

        public long CategoryId { get; set; }

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