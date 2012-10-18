using System.Collections.Generic;
using PresentationService.Models.CategoryModels.Items;
using PresentationService.Models.ProductModels;

namespace PresentationService.Models.CategoryModels
{
    public class CategoryViewModel
    {
        public CategoryViewModel(string categoryName, string categoryDescription, IEnumerable<ProductSmallModel> products, IEnumerable<CategoryListElementModel> subcategories)
        {
            Subcategories = subcategories;
            Products = products;
            CategoryName = categoryName;
            CategoryDescription = categoryDescription;
        }

        public string CategoryName { get; private set; }

        public string CategoryDescription { get; private set; }

        public IEnumerable<ProductSmallModel> Products { get; private set; }

        public IEnumerable<CategoryListElementModel> Subcategories { get; private set; } 
    }
}
