using System.Linq;
using DomainService.DomainModels;
using DomainService.DomainServiceInterfaces;
using DomainService.RepositoryInterfaces;

namespace DomainService.DomainServices
{
    public class UserDomainService : GenericDomainService<User, IGenericRepository<User>>, IUserDomainService
    {
        #region IUserDomainService Members

        public UserDomainService(IGenericRepository<User> repository) : base(repository)
        {
        }

        public User LoadByEmail(string email)
        {
            return Repository.Query().FirstOrDefault(u => u.Email == email);
        }

        public bool IsUniqueEmail(string email)
        {
            return Repository.Query().Count(u => u.Email == email) == 0;
        }

        #endregion
    }
}