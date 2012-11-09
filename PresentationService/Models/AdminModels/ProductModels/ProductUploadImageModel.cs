using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace PresentationService.Models.AdminModels.ProductModels
{

    public class ProductUploadImageModel : IValidatableObject
    {
        public HttpPostedFileBase File { get; set; }

        public string ImageUrl { get; set; }

        public bool Success { get; private set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (File == null || string.IsNullOrEmpty(ImageUrl))
            {
                yield return new ValidationResult("Вы должны или выбрать файл изображения или ввести URL на изображение.");
            }
        }
    }
}