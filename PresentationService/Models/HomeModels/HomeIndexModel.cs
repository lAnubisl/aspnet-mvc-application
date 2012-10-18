using System.Collections.Generic;
using PresentationService.Models.ProductModels;

namespace PresentationService.Models.HomeModels
{
    public class HomeIndexModel
    {
        public HomeIndexModel(IEnumerable<ProductSmallModel> topProducts)
        {
            TopProducts = topProducts;
        }

        public IEnumerable<ProductSmallModel> TopProducts { get; private set; }
    }
}