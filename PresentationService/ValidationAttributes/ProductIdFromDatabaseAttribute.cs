using DomainService.DomainServiceInterfaces;
using Foolproof;

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
            return IOC.ContainerInstance.Resolve<IProductDomainService>().Load(productId) != null;
        }
    }
}