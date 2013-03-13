using System.Collections.Generic;
using DomainService.DomainModels;

namespace PresentationService.Models.ProductModels
{
    public class ListProductModel
    {
        public ListProductModel(IEnumerable<Product> products, long categoryId)
        {
            CategoryId = categoryId;
            Products = products;
        }

        public long CategoryId { get; private set; }

        public IEnumerable<Product> Products { get; private set; }
    }
}