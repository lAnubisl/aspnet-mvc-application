using System;
using System.Linq;
using DomainService.DomainModels;
using PresentationService.Properties;

namespace PresentationService.Models.ProductModels
{
    public class ProductSmallModel
    {
        private readonly long productId;
        private readonly float productPrice;
        private readonly string productImage, productName, productDescription;

        internal ProductSmallModel(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException("product");
            }

            this.productName = product.Name;
            this.productPrice = product.Price;
            this.productDescription = product.Description;
            this.productId = product.Id;
            this.productImage = product.Images != null && product.Images.Any() 
                ? product.Images.First().Url 
                : Settings.Default.ProductDefaultImage;
        }

        public string ProductImage
        {
            get { return this.productImage; }
        }

        public long ProductId
        {
            get { return this.productId; }
        }

        public float ProductPrice
        {
            get { return this.productPrice; }
        }

        public string ProductName
        {
            get { return this.productName; }
        }

        public string ProduceDescription
        {
            get { return this.productDescription; }
        }
    }
}