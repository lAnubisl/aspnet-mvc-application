using System;
using System.Collections.Generic;
using System.Linq;
using DomainService.DomainModels;
using PresentationService.Models.ProductModels;

namespace PresentationService.Models.HomeModels
{
    public class HomeIndexModel
    {
        public HomeIndexModel(IEnumerable<Product> topProducts)
        {
            if (topProducts == null)
            {
                throw new ArgumentNullException("topProducts");
            }

            TopProducts = topProducts.Select(p => new ProductSmallModel(p));
        }

        public IEnumerable<ProductSmallModel> TopProducts { get; private set; }
    }
}