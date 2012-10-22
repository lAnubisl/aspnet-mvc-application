using System;
using DomainService.DomainModels;

namespace PresentationService.Models.CategoryModels.Items
{
    public class CategoryListElementModel
    {
        public CategoryListElementModel(Category category)
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