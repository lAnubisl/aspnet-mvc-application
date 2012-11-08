using System.Collections.Generic;
using DomainService.DomainModels;
using PresentationService.Models.AdminModels.ProductModels;

namespace PresentationService.Interfaces.Admin
{
    public interface IProductPresentationService : IBasePresentationService
    {     
        void SaveProductEditModel(ProductEditModel model);

        ProductIndexModel LoadProductIndexModel();

        ProductEditModel LoadProductEditModel(long id);

        IEnumerable<Product> LoadProductsForTerm(string term);
    }
}