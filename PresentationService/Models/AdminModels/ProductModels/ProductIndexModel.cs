using System.Collections.Generic;
using PresentationService.Models.AdminModels.ProductModels.Items;

namespace PresentationService.Models.AdminModels.ProductModels
{
    public class ProductIndexModel
    {
        public ProductIndexModel(IEnumerable<ProductIndexItemModel> products)
        {
            Products = products;
        }

        public IEnumerable<ProductIndexItemModel> Products { get; private set; }
    }
}