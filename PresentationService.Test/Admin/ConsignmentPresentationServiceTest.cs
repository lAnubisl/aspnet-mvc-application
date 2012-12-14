using System.Collections.Generic;
using DomainService.DomainModels;
using DomainService.DomainServiceInterfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PresentationService.Models.AdminModels.ConsignmentModels;
using PresentationService.Services.Admin;

namespace PresentationService.Test.Admin
{
    [TestClass]
    public class ConsignmentPresentationServiceTest
    {
        private Mock<IConsignmentDomainService> consignmentDomainService;
        private Mock<IProductDomainService> productDomainService;
        private Mock<IUserDomainService> userDomainService;
        private ConsignmentPresentationService service;

        [TestInitialize]
        public void Initialize()
        {
            consignmentDomainService = new Mock<IConsignmentDomainService>();
            productDomainService = new Mock<IProductDomainService>();
            userDomainService = new Mock<IUserDomainService>();
            service = new ConsignmentPresentationService(consignmentDomainService.Object, productDomainService.Object, userDomainService.Object);
        }

        [TestMethod]
        public void SaveConsignmentEditModel_Should_Save_Two_Identical_Products_Together()
        {
            userDomainService.Setup(x => x.Load(1)).Returns(new User());
            productDomainService.Setup(x => x.LoadByName("Product A")).Returns(new Product { Name = "Product A" });
            var model =
                new ConsignmentEditModel(
                    new Consignment 
                    {
                        IncomingProducts = 
                            new List<IncomingProduct>
                            { 
                                new IncomingProduct { Count = 1, Product = new Product { Name = "Product A" } },
                                new IncomingProduct { Count = 1, Product = new Product { Name = "Product A" } } 
                            }
                    });

            service.SaveConsignmentEditModel(model, 1);

            this.consignmentDomainService.Verify(x => x.Save(It.Is<Consignment>(c => c.IncomingProducts.Count == 1)), Times.Once());
        }
    }
}