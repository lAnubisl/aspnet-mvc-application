using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using PresentationService.ValidationAttributes;

namespace PresentationService.Models.AdminModels.ProductModels
{
    public class ProductUploadImageModel : IValidatableObject
    {       
        [FileValidation(MaxFileSize = 1 * 1024 * 1024)]
        public HttpPostedFileBase File { get; set; }

        [CommonLinkRegex]
        public string ImageUrl { get; set; }

        public string URL { get; private set; }

        public void SuccessModel(string fileUrl)
        {
            URL = fileUrl;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (File == null && string.IsNullOrEmpty(ImageUrl))
            {
                yield return new ValidationResult("Вы должны или выбрать файл изображения или ввести URL на изображение.");
            }
        }
    }
}