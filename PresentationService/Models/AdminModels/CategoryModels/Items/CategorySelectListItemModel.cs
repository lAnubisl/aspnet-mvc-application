using System;
using DomainService.DomainModels;

namespace PresentationService.Models.AdminModels.CategoryModels.Items
{
    public class CategorySelectListItemModel
    {
        private readonly long categoryId;
        private readonly string categoryName;

        internal CategorySelectListItemModel(Category category)
        {
            if (category == null)
            {
                throw new ArgumentNullException("category");
            }

            this.categoryId = category.Id;
            this.categoryName = category.Name;
        }

        public long CategoryId
        {
            get
            {
                return this.categoryId;
            }
        }

        public string CategoryName
        {
            get
            {
                return this.categoryName;
            }
        }
    }
}