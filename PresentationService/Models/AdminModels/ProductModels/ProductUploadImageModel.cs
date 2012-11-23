using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using PresentationService.ValidationAttributes;

namespace PresentationService.Models.AdminModels.ProductModels
{
    public class ProductUploadImageModel : IValidatableObject
    {
        [FileValidation(MaxFileSize = 1 * 1024 * 1024), DisplayName("Файл для загрузки")]
        public HttpPostedFileBase File { get; set; }

        [CommonLinkRegex, DisplayName("Ссылка на изображение")]
        public Uri ImageUrl { get; set; }

        public Uri Url { get; private set; }

        public void SuccessModel(Uri fileUrl)
        {
            Url = fileUrl;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (File == null && ImageUrl == null)
            {
                yield return new ValidationResult("Вы должны или выбрать файл изображения или ввести URL на изображение.");
            }
        }
    }
}