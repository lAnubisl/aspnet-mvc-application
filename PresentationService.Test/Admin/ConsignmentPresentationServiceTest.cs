using System.Collections.Generic;
using System.Linq;
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

        private const long defaultUserId = 1;

        [TestInitialize]
        public void Initialize()
        {
            this.consignmentDomainService = new Mock<IConsignmentDomainService>();
            this.productDomainService = new Mock<IProductDomainService>();
            this.userDomainService = new Mock<IUserDomainService>();
            this.service = new ConsignmentPresentationService(consignmentDomainService.Object, productDomainService.Object, userDomainService.Object);
            this.userDomainService.Setup(x => x.Load(defaultUserId)).Returns(new User());
        }

        [TestMethod]
        public void SaveConsignmentEditModel_Should_Save_Two_Identical_Products_Together()
        {
            this.productDomainService.Setup(x => x.LoadByName("Product A")).Returns(new Product { Name = "Product A" });
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

            service.SaveConsignmentEditModel(model, defaultUserId);

            this.consignmentDomainService.Verify(x => x.Save(It.Is<Consignment>(c => c.IncomingProducts.Count == 1)), Times.Once());
        }

        [TestMethod]
        public void SaveConsignmentEditModel_Should_Save_Two_Products()
        {
            this.productDomainService.Setup(x => x.LoadByName("Product A")).Returns(new Product { Name = "Product A" });
            this.productDomainService.Setup(x => x.LoadByName("Product B")).Returns(new Product { Name = "Product B" });
            var model = new ConsignmentEditModel(new Consignment
                {
                    IncomingProducts = new List<IncomingProduct>
                            { 
                                new IncomingProduct { Count = 1, Product = new Product { Name = "Product A" } },
                                new IncomingProduct { Count = 1, Product = new Product { Name = "Product B" } } 
                            }
                });

            service.SaveConsignmentEditModel(model, defaultUserId);
            this.consignmentDomainService.Verify(x => x.Save(It.Is<Consignment>(c => c.IncomingProducts.Count == 2)), Times.Once());
        }

        [TestMethod]
        public void SaveConsignmentEditModel_Should_Not_Save_Products_That_Does_Not_Exists()
        {
            this.productDomainService.Setup(x => x.LoadByName("Product B")).Returns(new Product { Name = "Product B" });
            var model = new ConsignmentEditModel(new Consignment
            {
                IncomingProducts = new List<IncomingProduct>
                            { 
                                new IncomingProduct { Count = 1, Product = new Product { Name = "Product C" } },
                                new IncomingProduct { Count = 1, Product = new Product { Name = "Product B" } } 
                            }
            });

            service.SaveConsignmentEditModel(model, defaultUserId);
            this.consignmentDomainService.Verify(x => x.Save(It.Is<Consignment>(c => c.IncomingProducts.Count(y => y.Product.Name == "Product C") == 0)), Times.Once());
        }
    }
}