﻿using System;
using DomainService.DomainModels;
using DomainService.DomainServiceInterfaces;
using PresentationService.Interfaces;
using PresentationService.Models.HomeModels;

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
            return new HomeIndexModel(productDomainService.LoadTopProducts(6, DateTime.Now, DateTime.Now));
        }
    }
}