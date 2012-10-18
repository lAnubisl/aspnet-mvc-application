using System;
using System.Collections.Generic;
using PresentationService.Models.ProductModels;

namespace PresentationService.Interfaces
{
    public interface IProductPresentationService : IBasePresentationService
    {
        ViewProductModel LoadViewProductModel(long productId);

        TopProductsModel LoadTopProductsModel(long count, DateTime startDate, DateTime endDate);

        ListProductModel LoadListProductModel(long categoryId);

        EditProductModel LoadNewEditProductModel();

        EditProductModel LoadEditProductModelById(long id);

        void SaveEditProductModel(EditProductModel model);

        IDictionary<string, string> ValidateEditProductModel(EditProductModel model);
    }
}