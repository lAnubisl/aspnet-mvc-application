using System;
using System.Linq;
using DomainService.DomainServiceInterfaces;
using PresentationService.Interfaces;
using PresentationService.Models.HomeModels;
using PresentationService.Models.ProductModels;

namespace PresentationService.Services
{
    public class HomePresentationService : IHomePresentationService
    {
        private readonly IAvailableProductDomainService productDomainService;

        public HomePresentationService(IAvailableProductDomainService productDomainService)
        {
            this.productDomainService = productDomainService;
        }

        public HomeIndexModel LoadHomeIndexModel()
        {
            return new HomeIndexModel(productDomainService.LoadTopProducts(6, DateTime.Now, DateTime.Now).Select(p => new ProductSmallModel(p.Id, p.Price, p.Name)));
        }
    }
}
