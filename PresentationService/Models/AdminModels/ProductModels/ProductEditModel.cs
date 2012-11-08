using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using DomainService.DomainModels;
using PresentationService.Helpers;
using PresentationService.Models.AdminModels.CategoryModels.Items;
using PresentationService.ValidationAttributes;

namespace PresentationService.Models.AdminModels.ProductModels
{
    public class ProductEditModel
    {
        private IEnumerable<string> productImages; 

        public ProductEditModel(
            Product product,
            IEnumerable<Category> availableCategories)
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
            AvailableCategories = availableCategories.Select(x => new CategorySelectListItemModel(x));
            if (product.Category != null)
            {
                CategoryId = product.Category.Id;
            }
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

        public string FileNames { get; set; }

        public User CreatedBy { get; set; }

        public IEnumerable<CategorySelectListItemModel> AvailableCategories { get; set; }

        public IEnumerable<string> ProductImages
        {
            get
            {
                if (productImages == null && ProductId != default(long))
                {
                    var dir = new DirectoryInfo(ProductImageHelper.BigImageDirectory);
                    var images = dir.GetFiles(string.Format(CultureInfo.InvariantCulture, "{0}_*.*", ProductId));
                    productImages = images.Select(image => image.Name).ToList();
                }

                return productImages;
            }
        }

        public IEnumerable<string> ProductTempImages
        {
            get
            {
                if (!string.IsNullOrEmpty(FileNames))
                {
                    var guids = FileNames.Split(',');
                    return guids.Where(guid => !string.IsNullOrEmpty(guid)).ToList();
                }

                return null;
            }
        }

        public bool HasImages
        {
            get
            {
                if ((ProductImages != null && ProductImages.Any()) || ProductTempImages != null)
                {
                    return true;
                }

                return false;
            }
        }
    }
}