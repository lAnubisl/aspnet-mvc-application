using DomainService.DomainServiceInterfaces;
using Foolproof;
using PresentationService.Models.AdminModels.ConsignmentModels.Items;

namespace PresentationService.ValidationAttributes
{
    internal sealed class ProductNameCombinedWithIdAttribute : ModelAwareValidationAttribute 
    {
        static ProductNameCombinedWithIdAttribute()
        {
            Register.Attribute(typeof(ProductNameCombinedWithIdAttribute));
        }

        public override bool IsValid(object value, object container)
        {
            if (value != null)
            {
                var name = (string)value;
                var model = (ConsignmentEditItemModel)container;
                var product = IOC.ContainerInstance.Resolve<IProductDomainService>().LoadByName(model.Name);
                if (product == null)
                {
                    return false;
                }

                return product.Name.Equals(name);
            }

            return false;
        }
    }
}
