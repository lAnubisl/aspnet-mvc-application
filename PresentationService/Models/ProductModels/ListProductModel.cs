using System.Collections.Generic;

namespace PresentationService.Models.ProductModels
{
    public class ListProductModel
    {
        public ListProductModel(IEnumerable<DomainService.DomainModels.Product> products, long categoryId)
        {
            CategoryId = categoryId;
            Products = products;
        }

        public long CategoryId { get; private set; }

        public IEnumerable<DomainService.DomainModels.Product> Products { get; private set; }
    }
}