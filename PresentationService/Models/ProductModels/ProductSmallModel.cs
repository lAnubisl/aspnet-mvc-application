using System;
using System.Linq;
using DomainService.DomainModels;
using PresentationService.Properties;

namespace PresentationService.Models.ProductModels
{
    public class ProductSmallModel
    {
        public ProductSmallModel(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException("product");
            }

            ProductName = product.Name;
            ProductPrice = product.Price;
            ProductId = product.Id;
            ProductImage = product.Images != null && product.Images.Any() 
                ? product.Images.First().URL 
                : Settings.Default.ProductDefaultImage;
        }

        public string ProductImage { get; private set; }

        public long ProductId { get; private set; }

        public float ProductPrice { get; private set; }

        public string ProductName { get; private set; }
    }
}