using System.Collections.Generic;

namespace PresentationService.Models.CategoryModels.Items
{
    public class CategoryMenuElementModel
    {
        public CategoryMenuElementModel(string categoryName, long categoryId, IEnumerable<CategoryMenuElementModel> subcategories)
        {
            Subcategories = subcategories;
            CategoryId = categoryId;
            CategoryName = categoryName;
        }

        public string CategoryName { get; private set; }

        public long CategoryId { get; private set; }

        public IEnumerable<CategoryMenuElementModel> Subcategories { get; private set; } 
    }
}