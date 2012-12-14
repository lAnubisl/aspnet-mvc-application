using System;
using System.Collections.Generic;
using System.Web;
using DomainService.DomainModels;
using DomainService.DomainServiceInterfaces;
using PresentationService.Interfaces.Admin;
using PresentationService.Models.AdminModels.ProductModels;
using PresentationService.Properties;

namespace PresentationService.Services.Admin
{
    public class ProductPresentationService : IProductPresentationService
    {
        private readonly IProductDomainService productDomainService;
        private readonly IImageDomainService imageDomainService;
        private readonly ICategoryDomainService categoryDomainService;

        public ProductPresentationService(
            IProductDomainService productDomainService,
            ICategoryDomainService categoryDomainService, 
            IImageDomainService imageDomainService)
        {
            this.productDomainService = productDomainService;
            this.categoryDomainService = categoryDomainService;
            this.imageDomainService = imageDomainService;
        }

        public string SaveProductImage(HttpPostedFileBase file, Uri url)
        {
            if (url != null)
            {
                var imageUrl = url.ToString();
                if (file != null)
                {                 
                    var fileName = imageUrl.Substring(imageUrl.LastIndexOf('/') + 1);
                    file.SaveAs(string.Format("{0}{1}/{2}", AppDomain.CurrentDomain.BaseDirectory, Settings.Default.ProductImagesPath, fileName));
                }

                imageDomainService.Save(new Image { Url = imageUrl });

                return imageUrl;
            }

            return null;
        }

        public ProductIndexModel LoadProductIndexModel()
        {
            return new ProductIndexModel(productDomainService.Load());
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
                product.IsUnlimitedProduct = model.IsUnlimitedProduct;
                AddImagesToProduct(product, imageDomainService.LoadByUrls(model.Images));
                productDomainService.Save(product);
            }
        }

        public IEnumerable<Product> LoadProductsForTerm(string term)
        {
            return productDomainService.LoadProductsForTerm(term);
        }

        public void DeleteImage(Uri imageUrl)
        {
            if (imageUrl != null)
            {
                var image = imageDomainService.LoadByUrl(imageUrl.ToString());
                if (image != null)
                {
                    imageDomainService.Delete(image);
                }
            }
        }

        private static void AddImagesToProduct(Product product, IEnumerable<Image> images)
        {
            if (product.Images == null)
            {
                product.Images = new List<Image>();
            }
            else
            {
                product.Images.Clear();
            }

            foreach (var image in images)
            {
                product.Images.Add(image);
            }
        }
    }
}