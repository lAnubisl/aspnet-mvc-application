using System;
using DomainService.DomainServiceInterfaces;
using PresentationService.Interfaces;
using PresentationService.Models.ProductModels;

namespace PresentationService.Services
{
    public class ProductPresentationService : IProductPresentationService
    {
        public IAvailableProductDomainService ProductDomainService { get; set; }

        #region IProductPresentationService Members

        public ViewProductModel LoadViewProductModel(long productId)
        {
            var product = ProductDomainService.Load(productId);
            if (product != null)
            {
                return new ViewProductModel(product);
            }

            return null;
        }

        public TopProductsModel LoadTopProductsModel(long count, DateTime startDate, DateTime endDate)
        {
            return new TopProductsModel(ProductDomainService.LoadTopProducts(count, startDate, endDate));
        }

        public ListProductModel LoadListProductModel(long categoryId)
        {
            return new ListProductModel(ProductDomainService.LoadByCategoryId(categoryId), categoryId);
        }

        #endregion
    }
}