using DomainService.DomainServiceInterfaces;
using Foolproof;
using PresentationService.Models.AdminModels.UserModels;

namespace PresentationService.ValidationAttributes
{
    internal sealed class UserShouldHaveUniqueEmailAttribute : ModelAwareValidationAttribute
    {
        ////this is needed to register this attribute with foolproof's validator adapter
        static UserShouldHaveUniqueEmailAttribute()
        {
            Register.Attribute(typeof(UserShouldHaveUniqueEmailAttribute));
        }

        public UserShouldHaveUniqueEmailAttribute()
        {
            ErrorMessage = "{0} уже зарегистрирован в системе";
        }

        public override bool IsValid(object value, object container)
        {
            if (value != null)
            {
                var email = value.ToString();

                if (!string.IsNullOrEmpty(value.ToString()))
                {
                    var model = (UserEditModel)container;
                    var userDomainService = IOC.ContainerInstance.Resolve<IUserDomainService>();
                    if (!userDomainService.IsUniqueEmail(model.UserId, email))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}