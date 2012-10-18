using Foolproof;
using PresentationService.Interfaces;
using PresentationService.Models.UserModels;

namespace PresentationService.ValidationAttributes
{
    internal sealed class PasswordValidationAttribute : ModelAwareValidationAttribute
    {
        static PasswordValidationAttribute()
        {
            Register.Attribute(typeof(PasswordValidationAttribute));
        }

        public override bool IsValid(object value, object container)
        {
            if (value == null || container == null)
            {
                return false;
            }

            var model = (LogOnUserModel)container;
            var userPresentationService = IOC.ContainerInstance.Resolve<IUserPresentationService>();
            return userPresentationService.ValidatePassword(model);
        }
    }
}
