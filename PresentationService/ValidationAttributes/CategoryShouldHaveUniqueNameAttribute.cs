using DomainService.DomainServiceInterfaces;
using Foolproof;
using PresentationService.Models.AdminModels.CategoryModels;

namespace PresentationService.ValidationAttributes
{
    internal sealed class CategoryShouldHaveUniqueNameAttribute : ModelAwareValidationAttribute
    {
        ////this is needed to register this attribute with foolproof's validator adapter
        static CategoryShouldHaveUniqueNameAttribute()
        {
            Register.Attribute(typeof(CategoryShouldHaveUniqueNameAttribute));
        }

        public override bool IsValid(object value, object container)
        {
            if (value != null)
            {
                var name = value.ToString();

                if (!string.IsNullOrEmpty(value.ToString()))
                {
                    var model = (CategoryEditModel)container;
                    var domainService = IOC.Resolve<ICategoryDomainService>();
                    if (!domainService.IsUniqueName(model.CategoryId, name))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}