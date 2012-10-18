using System.Collections.Generic;
using System.Linq;
using DomainService.DomainModels;
using DomainService.DomainServiceInterfaces;
using DomainService.RepositoryInterfaces;

namespace DomainService.DomainServices
{
    public class UserDomainService : GenericDomainService<User, IGenericRepository<User>>, IUserDomainService
    {
        #region IUserDomainService Members

        public User LoadByEmail(string email)
        {
            return Repository.Query().FirstOrDefault(u => u.Email == email);
        }

        public bool IsUniqueEmail(long userId, string email)
        {
            return !Repository.Query().Any(u => u.Id != userId && u.Email == email);
        }

        public bool IsUniqueEmail(string email)
        {
            return Repository.Query().Any(u => u.Email == email);
        }

        #endregion
    }
}