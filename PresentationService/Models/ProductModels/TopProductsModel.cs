using System.Collections.Generic;
using DomainService.DomainModels;

namespace PresentationService.Models.ProductModels
{
    public class TopProductsModel
    {
        private readonly IEnumerable<Product> products;

        public TopProductsModel(IEnumerable<Product> products)
        {
            this.products = products;
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