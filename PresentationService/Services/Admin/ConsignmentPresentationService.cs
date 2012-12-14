using System;
using System.Collections.Generic;
using System.Linq;
using DomainService.DomainModels;
using DomainService.DomainServiceInterfaces;
using DomainService.Enumerations;
using PresentationService.Interfaces.Admin;
using PresentationService.Models.AdminModels.ConsignmentModels;

namespace PresentationService.Services.Admin
{
    public class ConsignmentPresentationService : IConsignmentPresentationService
    {
        private readonly IConsignmentDomainService consignmentDomainService;

        private readonly IProductDomainService productDomainService;

        private readonly IUserDomainService userDomainService;

        public ConsignmentPresentationService(IConsignmentDomainService consignmentDomainService, IProductDomainService productDomainService, IUserDomainService userDomainService)
        {
            this.consignmentDomainService = consignmentDomainService;
            this.productDomainService = productDomainService;
            this.userDomainService = userDomainService;
        }

        public ConsignmentIndexModel LoadConsignmentIndexModel()
        {
            return new ConsignmentIndexModel(consignmentDomainService.Load());
        }

        public ConsignmentEditModel LoadConsignmentEditModel(long consignmentId)
        {
            var consignment = consignmentId != default(long)
                                  ? consignmentDomainService.Load(consignmentId)
                                  : new Consignment { Status = ConsignmentStatus.Waiting };

            if (consignment != null)
            {
                return new ConsignmentEditModel(consignment);
            }

            return null;
        }

        public void SaveConsignmentEditModel(ConsignmentEditModel consignmentEditModel, long userId)
        {
            if (consignmentEditModel == null)
            {
                throw new ArgumentNullException("consignmentEditModel");
            }

            var user = userDomainService.Load(userId);

            if (user == null)
            {
                throw new InvalidOperationException("There is no such user in the system");
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
                    var existingProduct = consignment.IncomingProducts.SingleOrDefault(x => x.Product.Name == product.Name);
                    if (existingProduct != null)
                    {
                        existingProduct.Count += product.Count;
                    }
                    else
                    {
                        consignment.IncomingProducts.Add(new IncomingProduct
                        {
                            Consignment = consignment,
                            Count = product.Count,
                            Product = productDomainService.LoadByName(product.Name)
                        });
                    }
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