using System;
using System.Collections.Generic;
using DomainService.DomainModels;
using DomainService.DomainServices;
using DomainService.RepositoryInterfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;

namespace DomainService.Test
{
    [TestClass]
    public class ProductDomainServiceUnitTests
    {
        [TestMethod]
        public void LoadByNameShouldReturnProductByName()
        {
            var fakeDB = new Mock<IGenericRepository<Product>>();
            fakeDB.Setup(x => x.Query()).Returns(new List<Product>
                {
                    new Product { Name = "Product A" },
                    new Product { Name = "Product B" },
                    new Product { Name = "Product C" }
                }.AsQueryable);

            var service = new ProductDomainService(fakeDB.Object);
            Assert.IsTrue(service.LoadByName("Product A") != null);
            Assert.IsTrue(service.LoadByName("Product D") == null);
        }

        [TestMethod, ExpectedException(typeof(InvalidOperationException))]
        public void LoadByNameShouldThrowExceptionInCaseOfTwoProductsWithTheSameName()
        {
            var fakeDB = new Mock<IGenericRepository<Product>>();
            fakeDB.Setup(x => x.Query()).Returns(new List<Product>
                {
                    new Product { Name = "Product A" },
                    new Product { Name = "Product A" }
                }.AsQueryable);

            var service = new ProductDomainService(fakeDB.Object);
            service.LoadByName("Product A");
        }

        [TestMethod]
        public void LoadProductsForTermShouldReturnProductsByTerm()
        {
            var fakeDB = new Mock<IGenericRepository<Product>>();
            fakeDB.Setup(x => x.Query()).Returns(new List<Product>
                {
                    new Product { Name = "Red bicycle" },
                    new Product { Name = "Yellow umbrella" },
                    new Product { Name = "White pillow" },
                    new Product { Name = "Red pillow" },
                    new Product { Name = "Red umbrella" },
                    new Product { Name = "White umbrella" },
                    new Product { Name = "Black redemption" }
                }.AsQueryable);
            var service = new ProductDomainService(fakeDB.Object);
            Assert.IsTrue(service.LoadProductsForTerm("Red").Count() == 4);
        }
    }
}
