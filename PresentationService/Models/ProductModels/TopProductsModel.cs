using System.Collections.Generic;

namespace PresentationService.Models.ProductModels
{
    public class TopProductsModel
    {
        public TopProductsModel(IEnumerable<DomainService.DomainModels.Product> products)
        {
            Products = products;
        }

        public IEnumerable<DomainService.DomainModels.Product> Products { get; private set; }
    }
}