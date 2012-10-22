using System;
using DomainService.DomainModels;

namespace PresentationService.Models.AdminModels.CategoryModels.Items
{
    public class CategorySelectListItemModel
    {
        public CategorySelectListItemModel(Category category)
        {
            if (category == null)
            {
                throw new ArgumentNullException("category");
            }

            CategoryId = category.Id;
            CategoryName = category.Name;
        }

        public long CategoryId { get; private set; }

        public string CategoryName { get; private set; }
    }
}