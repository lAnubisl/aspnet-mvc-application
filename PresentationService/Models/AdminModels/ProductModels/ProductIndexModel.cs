using System;
using System.Collections.Generic;
using System.Linq;
using DomainService.DomainModels;
using PresentationService.Models.AdminModels.ProductModels.Items;

namespace PresentationService.Models.AdminModels.ProductModels
{
    public class ProductIndexModel
    {
        public ProductIndexModel(IEnumerable<Product> products)
        {
            if (products == null)
            {
                throw new ArgumentNullException("products");
            }

            Products = products.Select(p => new ProductIndexItemModel(p.Name, p.Id));
        }

        public IEnumerable<ProductIndexItemModel> Products { get; private set; }
    }
}