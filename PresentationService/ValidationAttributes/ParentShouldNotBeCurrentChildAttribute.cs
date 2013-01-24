using System.Linq;
using Foolproof;
using PresentationService.Models.AdminModels.CategoryModels;

namespace PresentationService.ValidationAttributes
{
    internal sealed class ParentShouldNotBeCurrentChildAttribute : ModelAwareValidationAttribute
    {
        static ParentShouldNotBeCurrentChildAttribute()
        {
            Register.Attribute(typeof(ParentShouldNotBeCurrentChildAttribute));
        }

        public override bool IsValid(object value, object container)
        {
            if (value != null)
            {
                if (!string.IsNullOrEmpty(value.ToString()))
                {
                    var model = (CategoryEditModel)container;
                    return model.ParentCategories.Any(c => c.CategoryId == model.ParentCategoryId);
                }
            }

            return true;
        }
    }
}