using System.Web.Mvc;
using MVCApplication.Common;
using PresentationService.Properties;

namespace MVCApplication.Controllers.Helpers
{
    public static class ProductImageHelper
    {
        public static string ProductImage(this HtmlHelper htmlHelper, string imageName, ImageSize size)
        {
            var images = Settings.Default.ProductImagesPath;
            var big = Settings.Default.ProductImagesBigPostfix;
            var small = Settings.Default.ProductImagesSmallPostfix;

            return string.Format("~{0}{1}/{2}", images, size == ImageSize.Big ? big : small, imageName);
        }

        public static string ProductTempImage(this HtmlHelper htmlHelper, string imgGuid, ImageSize size)
        {
            return ProductTempImage(imgGuid, size);
        }

        public static string ProductTempImage(string imgGuid, ImageSize size)
        {
            var images = Settings.Default.ProductImagesTempPath;
            var big = Settings.Default.ProductImagesBigPostfix;
            var small = Settings.Default.ProductImagesSmallPostfix;

            return string.Format("~{0}{1}/{2}", images, size == ImageSize.Big ? big : small, imgGuid);
        }
    }
}