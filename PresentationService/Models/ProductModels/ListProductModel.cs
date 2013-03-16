using System.Collections.Generic;
using DomainService.DomainModels;

namespace PresentationService.Models.ProductModels
{
    public class ListProductModel
    {
        private readonly long categoryId;
        private readonly IEnumerable<Product> products;

        public ListProductModel(IEnumerable<Product> products, long categoryId)
        {
            this.categoryId = categoryId;
            this.products = products;
        }

        public long CategoryId 
        { 
            get 
            { 
                return this.categoryId; 
            } 
        }

        public IEnumerable<Product> Products 
        { 
            get 
            { 
                return this.products; 
            } 
        }
    }
}