using System;
using System.Collections.Generic;
using System.IO;
using DomainService.DomainModels;
using PresentationService.Models.AdminModels.ProductModels;

namespace PresentationService.Interfaces.Admin
{
    public interface IProductPresentationService : IBasePresentationService
    {
        bool DeleteImage(string fileName);
        
        void SaveProductEditModel(ProductEditModel model);

        ProductIndexModel LoadProductIndexModel();

        ProductEditModel LoadProductEditModel(long id);

        string SaveUploadedImage(Stream fileStream);

        IEnumerable<Product> LoadProductsForTerm(string term);
    }
}