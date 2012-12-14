﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using DomainService.DomainModels;
using PresentationService.Models.AdminModels.CategoryModels.Items;
using PresentationService.ValidationAttributes;

namespace PresentationService.Models.AdminModels.CategoryModels
{
    public class CategoryEditModel
    {
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
            ParentCategories = parentCategories.Select(c => new CategorySelectListItemModel(c));
        }

        [DisplayName("Название"), CommonRequired, CommonStringLength(50), CategoryShouldHaveUniqueName]
        public string CategoryName { get; set; }

        [DisplayName("Описание")]
        public string CategoryDescription { get; set; }

        public string SeoURL { get; set; }

        public long CategoryId { get; set; }

        [DisplayName("Родительская категория"), ParentShouldNotBeCurrentChild]
        public long? ParentCategoryId { get; set; }

        public IEnumerable<CategorySelectListItemModel> ParentCategories { get; private set; } 
    }
}