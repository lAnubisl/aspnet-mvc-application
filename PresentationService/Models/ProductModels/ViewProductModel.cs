using System;
using System.Collections.Generic;
using System.Linq;
using DomainService.DomainModels;

namespace PresentationService.Models.ProductModels
{
    public class ViewProductModel
    {
        public ViewProductModel(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException("product");
            }

            ProductDescription = product.Description;
            ProductPrice = product.Price;
            ProductName = product.Name;
            ProductId = product.Id;
            ProductImages = product.Images.Select(x => x.URL).ToList();
        }

        public long ProductId { get; private set; }

        public string ProductName { get; private set; }

        public float ProductPrice { get; private set; }

        public string ProductDescription { get; private set; }

        public IEnumerable<string> ProductImages { get; private set; } 
    }
}