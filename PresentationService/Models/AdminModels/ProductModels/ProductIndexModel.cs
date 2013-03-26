using System;
using System.Collections.Generic;
using System.Linq;
using DomainService.DomainModels;
using PresentationService.Models.AdminModels.ProductModels.Items;

namespace PresentationService.Models.AdminModels.ProductModels
{
    public class ProductIndexModel
    {
        private readonly IEnumerable<ProductIndexItemModel> products;

        internal ProductIndexModel(IEnumerable<Product> products)
        {
            if (products == null)
            {
                throw new ArgumentNullException("products");
            }

            this.products = products.Select(p => new ProductIndexItemModel(p.Name, p.Id));
        }

        public IEnumerable<ProductIndexItemModel> Products
        {
            get
            {
                return this.products;
            }
        }
    }
}