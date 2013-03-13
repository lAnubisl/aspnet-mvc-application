using System.Collections.Generic;
using DomainService.DomainModels;

namespace PresentationService.Models.ProductModels
{
    public class TopProductsModel
    {
        public TopProductsModel(IEnumerable<Product> products)
        {
            Products = products;
        }

        public IEnumerable<Product> Products { get; private set; }
    }
}