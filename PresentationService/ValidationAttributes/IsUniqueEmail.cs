using System.ComponentModel.DataAnnotations;
using DomainService.DomainServiceInterfaces;

namespace PresentationService.ValidationAttributes
{
    internal sealed class IsUniqueEmail : ValidationAttribute
    {
        public IsUniqueEmail()
        {
            ErrorMessage = "{0} уже зарегистрирован в системе";
        }

        public override bool IsValid(object value)
        {
            if (value != null)
            {
                var email = value.ToString();

                if (!string.IsNullOrEmpty(value.ToString()))
                {
                    var userDomainService = IOC.ContainerInstance.Resolve<IUserDomainService>();
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