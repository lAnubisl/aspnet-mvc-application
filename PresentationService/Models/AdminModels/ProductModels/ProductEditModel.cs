using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using DomainService.DomainModels;
using PresentationService.Models.AdminModels.CategoryModels.Items;
using PresentationService.ValidationAttributes;

namespace PresentationService.Models.AdminModels.ProductModels
{
    public class ProductEditModel
    {
        private readonly IEnumerable<CategorySelectListItemModel> availableCategories;
        private readonly IEnumerable<string> images; 

        public ProductEditModel(Product product, IEnumerable<Category> availableCategories)
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

        public long ProductId { get; set; }

        [DisplayName("Название"), CommonRequired, CommonStringLength(50)]
        public string ProductName { get; set; }

        [DisplayName("Цена")]
        public float ProductPrice { get;  set; }

        [DisplayName("Описание"), CommonRequired]
        public string ProductDescription { get; set; }

        [DisplayName("Неограниченное количество")]
        public bool IsUnlimitedProduct { get; set; }

        [DisplayName("Категория")]
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