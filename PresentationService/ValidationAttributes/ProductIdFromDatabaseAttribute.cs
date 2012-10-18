using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomainService.DomainServiceInterfaces;
using Foolproof;
using PresentationService.Interfaces.Admin;

namespace PresentationService.ValidationAttributes
{
    internal sealed class ProductIdFromDatabaseAttribute : ModelAwareValidationAttribute
    {
        static ProductIdFromDatabaseAttribute()
        {
            Register.Attribute(typeof(ProductIdFromDatabaseAttribute));
        }

        public override bool IsValid(object value, object container)
        {
            var productId = value is long ? (long)value : default(long);
            return IOC.ContainerInstance.Resolve<IProductDomainService>().Load().Any(p => p.Id == productId);
        }
    }
}
