using System;
using System.Globalization;
using System.IO;
using System.Linq;
using PresentationService.Properties;

namespace PresentationService.Models.ProductModels
{
    public class ProductSmallModel
    {
        private string productImage;

        public ProductSmallModel(long productId, float productPrice, string productName)
        {
            ProductName = productName;
            ProductPrice = productPrice;
            ProductId = productId;
        }

        public string ProductImage
        {
            get
            {
                if (productImage == null && ProductId != default(long))
                {
                    var dir = new DirectoryInfo(string.Format(CultureInfo.InvariantCulture, "{0}{1}{2}", AppDomain.CurrentDomain.BaseDirectory, Settings.Default.ProductImagesPath, Settings.Default.ProductImagesBigPostfix));
                    var images = dir.GetFiles(string.Format(CultureInfo.InvariantCulture, "{0}_*.jpg", ProductId));
                    productImage = images.Select(image => image.Name).FirstOrDefault();
                }

                return productImage;
            }
        }

        public long ProductId { get; private set; }

        public float ProductPrice { get; private set; }

        public string ProductName { get; private set; }
    }
}