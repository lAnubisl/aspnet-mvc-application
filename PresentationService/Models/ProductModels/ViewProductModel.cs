using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using PresentationService.Properties;

namespace PresentationService.Models.ProductModels
{
    public class ViewProductModel
    {
        private IEnumerable<string> productImages;

        public ViewProductModel(long productId, string productName, float productPrice, string productDescription)
        {
            ProductDescription = productDescription;
            ProductPrice = productPrice;
            ProductName = productName;
            ProductId = productId;
        }

        public long ProductId { get; private set; }

        public string ProductName { get; private set; }

        public float ProductPrice { get; private set; }

        public string ProductDescription { get; private set; }

        public IEnumerable<string> ProductImages
        {
            get
            {
                if (productImages == null && ProductId != default(long))
                {
                    var dir = new DirectoryInfo(string.Format(CultureInfo.InvariantCulture, "{0}{1}{2}", AppDomain.CurrentDomain.BaseDirectory, Settings.Default.ProductImagesPath, Settings.Default.ProductImagesBigPostfix));
                    var images = dir.GetFiles(string.Format(CultureInfo.InvariantCulture, "{0}_*.jpg", ProductId));
                    productImages = images.Select(image => image.Name).ToList();
                }

                return productImages;
            }
        }
    }
}