using System;
using System.Collections.Generic;
using DomainService.DomainModels;
using DomainService.DomainServiceInterfaces;
using PresentationService.Interfaces.Admin;
using PresentationService.Models.AdminModels.ConsignmentModels;

namespace PresentationService.Services.Admin
{
    public class ConsignmentPresentationService : IConsignmentPresentationService
    {
        private readonly IConsignmentDomainService consignmentDomainService;

        private readonly IProductDomainService productDomainService;

        public ConsignmentPresentationService(IConsignmentDomainService consignmentDomainService, IProductDomainService productDomainService)
        {
            this.consignmentDomainService = consignmentDomainService;
            this.productDomainService = productDomainService;
        }

        public ConsignmentIndexModel LoadConsignmentIndexModel()
        {
            return new ConsignmentIndexModel(consignmentDomainService.Load());
        }

        public ConsignmentEditModel LoadConsignmentEditModel(long consignmentId)
        {
            var consignment = consignmentId != default(long)
                                  ? consignmentDomainService.Load(consignmentId)
                                  : new Consignment();

            if (consignment != null)
            {
                return new ConsignmentEditModel(consignment);
            }

            return null;
        }

        public void SaveConsignmentEditModel(ConsignmentEditModel consignmentEditModel, User user)
        {
            if (consignmentEditModel == null)
            {
                throw new ArgumentNullException("consignmentEditModel");
            }

            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            var consignment = consignmentEditModel.Id != default(long)
                ? consignmentDomainService.Load(consignmentEditModel.Id) 
                : new Consignment { CreationDate = DateTime.Now, User = user, IncomingProducts = new List<IncomingProduct>() };

            if (consignment != null)
            {
                consignment.Status = consignmentEditModel.Status;
                consignment.IncomingProducts.Clear();
                foreach (var product in consignmentEditModel.Products)
                {
                    consignment.IncomingProducts.Add(new IncomingProduct
                    {
                        Consignment = consignment,
                        Count = product.Count,
                        Product = productDomainService.LoadByName(product.Name)
                    });
                }

                consignmentDomainService.Save(consignment);
            }
        }

        public ConsignmentDetailsModel LoadConsignmentDetailsModel(long consignmentId)
        {
            var consignment = consignmentDomainService.Load(consignmentId);
            if (consignment != null)
            {
                return new ConsignmentDetailsModel(consignment);
            }

            return null;
        }
    }
}