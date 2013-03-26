using System;
using System.Collections.Generic;
using System.Linq;
using DomainService.DomainModels;

namespace PresentationService.Models.ProductModels
{
    public class ViewProductModel
    {
        private readonly long productId;
        private readonly float productPrice;
        private readonly string productName, productDescription;
        private readonly IEnumerable<string> productImages;

        internal ViewProductModel(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException("product");
            }

            this.productDescription = product.Description;
            this.productPrice = product.Price;
            this.productName = product.Name;
            this.productId = product.Id;
            this.productImages = product.Images.Select(x => x.Url).ToList();
        }

        public long ProductId
        {
            get
            {
                return this.productId;
            }
        }
         
        public string ProductName
        {
            get
            {
                return this.productName;
            }
        }

        public float ProductPrice
        {
            get
            {
                return this.productPrice;
            }
        }

        public string ProductDescription
        { 
            get 
            { 
                return this.productDescription;
            }
        }

        public IEnumerable<string> ProductImages
        {
            get
            {
                return this.productImages;
            }
        }
    }
}