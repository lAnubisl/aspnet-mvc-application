using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web;

namespace PresentationService.ValidationAttributes
{
    internal sealed class FileValidationAttribute : ValidationAttribute
    {
        public long MaxFileSize { get; set; }

        public override bool IsValid(object value)
        {
            var file = value as HttpPostedFileBase;
            if (file != null && file.ContentLength <= MaxFileSize)
            {
                try
                {
                    using (var img = Image.FromStream(file.InputStream))
                    {
                        return img.RawFormat.Equals(ImageFormat.Jpeg);
                    }
                }
                catch
                {
                }
            }

            return true;
        }
    }
}