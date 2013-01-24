using System;
using System.Security.Principal;
using DomainService.DomainModels;
using DomainService.DomainServiceInterfaces;
using PresentationService;

namespace MvcApplication.Common
{
    public class SystemUser : GenericPrincipal
    {
        private readonly User currentUser;

        public SystemUser(IIdentity identity, string[] roles)
            : base(identity, roles)
        {
            if (identity == null)
            {
                throw new ArgumentNullException("identity");
            }

            var userDomainService = IOC.Resolve<IUserDomainService>();
            currentUser = userDomainService.LoadByEmail(identity.Name.Split('/')[1]);
        }

        public User LoggedInUser
        {
            get { return currentUser; }
        }
    }
}