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
        private readonly string categoryName, categoryDescription;
        private readonly IEnumerable<ProductSmallModel> products;
        private readonly IEnumerable<CategoryListElementModel> subCategories;

        internal CategoryViewModel(Category category, IEnumerable<Product> products)
        {
            if (category == null)
            {
                throw new ArgumentNullException("category");
            }

            if (products == null)
            {
                throw new ArgumentNullException("products");
            }

            this.subCategories = category.ChildCategories.Select(c => new CategoryListElementModel(c));
            this.products = products.Select(p => new ProductSmallModel(p));
            this.categoryName = category.Name;
            this.categoryDescription = category.Description;
        }

        public string CategoryName 
        { 
            get 
            { 
                return this.categoryName; 
            } 
        }

        public string CategoryDescription 
        { 
            get 
            { 
                return this.categoryDescription; 
            } 
        }

        public IEnumerable<ProductSmallModel> Products 
        { 
            get 
            { 
                return this.products; 
            } 
        }

        public IEnumerable<CategoryListElementModel> Subcategories 
        { 
            get 
            { 
                return this.subCategories; 
            } 
        } 
    }
}