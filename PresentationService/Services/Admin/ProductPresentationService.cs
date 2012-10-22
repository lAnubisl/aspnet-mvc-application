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

                MoveTempImages(product.Id, model.FileNames.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries));
            }
        }

        public string SaveUploadedImage(Stream fileStream)
        {
            if (fileStream == null)
            {
                throw new ArgumentNullException("fileStream");
            }

            var originalImage = Image.FromStream(fileStream);

            var fileName = string.Format(CultureInfo.InvariantCulture, "{0}.jpg", Guid.NewGuid());

            ResizeAndSave(originalImage, 100, ProductImageHelper.GetSmallImageTempPath(fileName));
            ResizeAndSave(originalImage, 300, ProductImageHelper.GetBigImageTempPath(fileName));

            return fileName;
        }

        public IEnumerable<Product> LoadProductsForTerm(string term)
        {
            return productDomainService.LoadProductsForTerm(term);
        }

        public bool DeleteImage(string fileName)
        {
            if (!string.IsNullOrEmpty(fileName))
            {
                var persistentImages = Directory.GetFiles(ProductImageHelper.ImageDirectory, fileName, SearchOption.AllDirectories);
                var tempImages = Directory.GetFiles(ProductImageHelper.ImageTempDirectory, fileName, SearchOption.AllDirectories);
                if (persistentImages.Any() || tempImages.Any())
                {
                    foreach (var file in persistentImages.Union(tempImages))
                    {
                        File.Delete(file);
                    }

                    return true;
                }
            }

            return false;
        }

        private static void MoveTempImages(long productId, IEnumerable<string> fileNames)
        {
            if (fileNames != null && productId != default(long))
            {
                foreach (var fileName in fileNames)
                {
                    var newFileName = string.Format(CultureInfo.InvariantCulture, "{0}_{1}", productId, fileName);
                    File.Move(ProductImageHelper.GetSmallImageTempPath(fileName), ProductImageHelper.GetSmallImagePath(newFileName));
                    File.Move(ProductImageHelper.GetBigImageTempPath(fileName), ProductImageHelper.GetBigImagePath(newFileName));
                }
            }
        }

        private static void ResizeAndSave(Image oldImage, int newWidth, string pathToSave)
        {
            var scale = (float)newWidth / oldImage.Width;
            var newHeight = (int)Math.Floor(oldImage.Height * scale);

            using (var newImage = new Bitmap(newWidth, newHeight))
            {
                var newSizeRectangle = new Rectangle(0, 0, newWidth, newHeight);
                var graphics = Graphics.FromImage(newImage);
                graphics.DrawImage(oldImage, newSizeRectangle);
                newImage.Save(pathToSave);
            }
        }
    }
}