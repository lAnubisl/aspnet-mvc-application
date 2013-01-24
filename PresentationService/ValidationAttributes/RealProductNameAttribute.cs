using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using DomainService.DomainServiceInterfaces;

namespace PresentationService.ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class RealProductNameAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                var productName = value as string;
                if (!string.IsNullOrEmpty(productName))
                {
                    var service = IOC.Resolve<IProductDomainService>();
                    if (service.LoadByName(productName) == null)
                    {
                        ErrorMessage = string.Format(CultureInfo.CurrentCulture, Resources.ValidationMessages.Product_X_DoesNotExistsInTheSystem, productName);
                        return false;
                    }
                }
            }

            return true;
        }
    }
}