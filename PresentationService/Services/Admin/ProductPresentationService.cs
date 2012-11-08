using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using DomainService.DomainModels;
using DomainService.DomainServiceInterfaces;
using PresentationService.Helpers;
using PresentationService.Interfaces.Admin;
using PresentationService.Models.AdminModels.ProductModels;
using PresentationService.Models.AdminModels.ProductModels.Items;
using Image = System.Drawing.Image;

namespace PresentationService.Services.Admin
{
    public class ProductPresentationService : IProductPresentationService
    {
        private readonly IProductDomainService productDomainService;

        private readonly ICategoryDomainService categoryDomainService;

        public ProductPresentationService(
            IProductDomainService productDomainService,
            ICategoryDomainService categoryDomainService)
        {
            this.productDomainService = productDomainService;
            this.categoryDomainService = categoryDomainService;
        }
      
        public ProductIndexModel LoadProductIndexModel()
        {
            return new ProductIndexModel(productDomainService.Load().Select(p => new ProductIndexItemModel(p.Name, p.Id)));
        }

        public ProductEditModel LoadProductEditModel(long id)
        {
            var product = id != default(long)
                              ? productDomainService.Load(id)
                              : new Product();

            if (product != null)
            {
                return new ProductEditModel(product, categoryDomainService.Load());
            }

            return null;
        }

        public void SaveProductEditModel(ProductEditModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("model");
            }

            var product = model.ProductId != default(long)
                   ? productDomainService.Load(model.ProductId)
                   : new Product();
            if (product != null)
            {
                product.Name = model.ProductName;
                product.Description = model.ProductDescription;
                product.Price = model.ProductPrice;
                product.Id = model.ProductId;
                product.Category = categoryDomainService.Load(model.CategoryId);
                product.CreatedBy = model.CreatedBy;
                productDomainService.Save(product);
            }
        }

        public IEnumerable<Product> LoadProductsForTerm(string term)
        {
            return productDomainService.LoadProductsForTerm(term);
        }
    }
}