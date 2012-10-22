using System;
using System.Collections.Generic;
using System.Linq;
using DomainService.DomainModels;
using PresentationService.Models.CategoryModels.Items;
using PresentationService.Models.ProductModels;

namespace PresentationService.Models.CategoryModels
{
    public class CategoryViewModel
    {
        public CategoryViewModel(Category category, IEnumerable<Product> products)
        {
            if (category == null)
            {
                throw new ArgumentNullException("category");
            }

            if (products == null)
            {
                throw new ArgumentNullException("products");
            }

            Subcategories = category.ChildCategories.Select(c => new CategoryListElementModel(c));
            Products = products.Select(p => new ProductSmallModel(p));
            CategoryName = category.Name;
            CategoryDescription = category.Description;
        }

        public string CategoryName { get; private set; }

        public string CategoryDescription { get; private set; }

        public IEnumerable<ProductSmallModel> Products { get; private set; }

        public IEnumerable<CategoryListElementModel> Subcategories { get; private set; } 
    }
}
