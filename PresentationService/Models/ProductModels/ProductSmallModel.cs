using System;
using System.Linq;
using DomainService.DomainModels;
using PresentationService.Properties;

namespace PresentationService.Models.ProductModels
{
    public class ProductSmallModel
    {
        private readonly long productId;
        private readonly string productImage;
        private readonly string productName;
        private readonly float productPrice;
        private readonly string productDescription;

        public ProductSmallModel(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException("product");
            }

            productName = product.Name;
            productPrice = product.Price;
            productDescription = product.Description;
            productId = product.Id;
            productImage = product.Images != null && product.Images.Any() 
                ? product.Images.First().Url 
                : Settings.Default.ProductDefaultImage;
        }

        public string ProductImage
        {
            get { return productImage; }
        }

        public long ProductId
        {
            get { return productId; }
        }

        public float ProductPrice
        {
            get { return productPrice; }
        }

        public string ProductName
        {
            get { return productName; }
        }

        public string ProduceDescription
        {
            get { return productDescription; }
        }
    }
}