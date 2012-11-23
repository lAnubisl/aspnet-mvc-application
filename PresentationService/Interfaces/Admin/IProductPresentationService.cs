using System;
using System.Collections.Generic;
using System.Web;
using DomainService.DomainModels;
using PresentationService.Models.AdminModels.ProductModels;

namespace PresentationService.Interfaces.Admin
{
    public interface IProductPresentationService : IBasePresentationService
    {     
        void SaveProductEditModel(ProductEditModel model);

        string SaveProductImage(HttpPostedFileBase file, Uri url);

        ProductIndexModel LoadProductIndexModel();

        ProductEditModel LoadProductEditModel(long id);

        IEnumerable<Product> LoadProductsForTerm(string term);

        void DeleteImage(Uri imageUrl);
    }
}