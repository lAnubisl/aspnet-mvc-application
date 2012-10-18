using System.Security.Principal;
using DomainService.DomainModels;
using DomainService.DomainServiceInterfaces;
using PresentationService;

namespace MVCApplication.Common
{
    public class SystemUser : GenericPrincipal
    {
        private readonly User currentUser;

        public SystemUser(IIdentity identity, string[] roles)
            : base(identity, roles)
        {
            var userDomainService = IOC.ContainerInstance.Resolve<IUserDomainService>();
            currentUser = userDomainService.LoadByEmail(identity.Name.Split('/')[1]);
        }

        public User LoggedInUser
        {
            get { return currentUser; }
        }
    }
}