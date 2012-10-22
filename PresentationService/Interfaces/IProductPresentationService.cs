using System;
using PresentationService.Models.ProductModels;

namespace PresentationService.Interfaces
{
    public interface IProductPresentationService : IBasePresentationService
    {
        ViewProductModel LoadViewProductModel(long productId);

        TopProductsModel LoadTopProductsModel(long count, DateTime startDate, DateTime endDate);
    }
}