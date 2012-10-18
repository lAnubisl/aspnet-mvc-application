using System;
using System.Globalization;
using PresentationService.Properties;

namespace PresentationService.Helpers
{
    public static class ProductImageHelper
    {
        public static string ImageDirectory
        {
            get
            {
                return string.Format(CultureInfo.InvariantCulture, "{0}{1}", AppDomain.CurrentDomain.BaseDirectory, Settings.Default.ProductImagesPath);
            }
        }

        public static string ImageTempDirectory
        {
            get
            {
                return string.Format(CultureInfo.InvariantCulture, "{0}{1}", AppDomain.CurrentDomain.BaseDirectory, Settings.Default.ProductImagesTempPath);
            }
        }

        public static string BigImageDirectory
        {
            get
            {
                return string.Format(CultureInfo.InvariantCulture, "{0}{1}", ImageDirectory, Settings.Default.ProductImagesBigPostfix);
            }
        }

        public static string GetSmallImageTempPath(string fileName)
        {
            return string.Format(CultureInfo.InvariantCulture, "{0}{1}/{2}", ImageTempDirectory, Settings.Default.ProductImagesSmallPostfix, fileName);
        }

        public static string GetBigImageTempPath(string fileName)
        {
            return string.Format(CultureInfo.InvariantCulture, "{0}{1}/{2}", ImageTempDirectory, Settings.Default.ProductImagesBigPostfix, fileName);
        }

        public static string GetSmallImagePath(string fileName)
        {
            return string.Format(CultureInfo.InvariantCulture, "{0}{1}/{2}", ImageDirectory, Settings.Default.ProductImagesBigPostfix, fileName);
        }

        public static string GetBigImagePath(string fileName)
        {
            return string.Format(CultureInfo.InvariantCulture, "{0}/{1}", BigImageDirectory, fileName);
        }
    }
}