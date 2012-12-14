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
            if (file != null)
            {
                if (file.ContentLength > MaxFileSize)
                {
                    ErrorMessage = Resources.ValidationMessages.FileExceedsTheSizeLimit;
                    return false;
                }

                using (var img = Image.FromStream(file.InputStream))
                {
                    if (!img.RawFormat.Equals(ImageFormat.Jpeg))
                    {
                        ErrorMessage = Resources.ValidationMessages.FileFormatIsNotAllowed;
                        return false;
                    }
                }
            }

            return true;
        }
    }
}