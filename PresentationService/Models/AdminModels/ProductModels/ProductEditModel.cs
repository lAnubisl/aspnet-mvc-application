using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using DomainService.DomainModels;
using PresentationService.Models.AdminModels.CategoryModels.Items;
using PresentationService.Resources;
using PresentationService.ValidationAttributes;

namespace PresentationService.Models.AdminModels.ProductModels
{
    public class ProductEditModel
    {
        private readonly IEnumerable<CategorySelectListItemModel> availableCategories;
        private readonly IEnumerable<string> images; 

        internal ProductEditModel(Product product, IEnumerable<Category> availableCategories)
        {
            if (product == null)
            {
                throw new ArgumentNullException("product");
            }

            if (availableCategories == null)
            {
                throw new ArgumentNullException("availableCategories");
            }

            ProductDescription = product.Description;
            ProductPrice = product.Price;
            ProductName = product.Name;
            ProductId = product.Id;
            IsUnlimitedProduct = product.IsUnlimitedProduct;
            this.availableCategories = availableCategories.Select(x => new CategorySelectListItemModel(x));
            if (product.Category != null)
            {
                CategoryId = product.Category.Id;
            }
            
            images = (product.Images != null && product.Images.Any()) 
                ? product.Images.Select(x => x.Url).ToList()
                : new List<string>();
        }

        public long ProductId { get; private set; }

        [Display(Name = "ProductName", ResourceType = typeof(EntityNames)), CommonRequired, CommonStringLength(50)]
        public string ProductName { get; set; }

        [Display(Name = "ProductPrice", ResourceType = typeof(EntityNames))]
        public float ProductPrice { get; set; }

        [Display(Name = "ProductDescription", ResourceType = typeof(EntityNames)), CommonRequired]
        public string ProductDescription { get; set; }

        [Display(Name = "ProductUnlimited", ResourceType = typeof(EntityNames))]
        public bool IsUnlimitedProduct { get; set; }

        [Display(Name = "Category", ResourceType = typeof(EntityNames))]
        public long CategoryId { get; set; }

        public User CreatedBy { get; set; }

        public IEnumerable<string> Images
        {
            get { return images; }
        }

        public IEnumerable<CategorySelectListItemModel> AvailableCategories
        {
            get { return availableCategories; }
        }
    }
}