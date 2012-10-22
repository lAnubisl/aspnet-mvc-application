using DomainService.DomainModels;

namespace DomainService.DomainServiceInterfaces
{
    public interface IUserDomainService : IGenericDomainService<User>
    {
        /// <summary>
        /// Load user by email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        User LoadByEmail(string email);

        /// <summary>
        /// Ensures that <param name="email"></param> is unique
        /// </summary>
        /// <param name="email"></param>
        /// <returns>True if email is unique, otherwise false</returns>
        bool IsUniqueEmail(string email);
    }
}