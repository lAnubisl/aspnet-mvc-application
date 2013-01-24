using System.ComponentModel.DataAnnotations;
using DomainService.DomainServiceInterfaces;

namespace PresentationService.ValidationAttributes
{
    internal sealed class IsUniqueEmailAttribute : ValidationAttribute
    {
        public IsUniqueEmailAttribute()
        {
            ErrorMessage = Resources.ValidationMessages.X_AlreadyExistsInTheSystem;
        }

        public override bool IsValid(object value)
        {
            if (value != null)
            {
                var email = value.ToString();

                if (!string.IsNullOrEmpty(email))
                {
                    var userDomainService = IOC.Resolve<IUserDomainService>();
                    if (!userDomainService.IsUniqueEmail(email))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}