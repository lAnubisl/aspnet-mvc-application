using System;
using DomainService.DomainModels;
using DomainService.Enumerations;

namespace PresentationService.Models.UserModels
{
    public class CookieModel
    {
        public CookieModel(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email;
            Role = user.Role;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public Role Role { get; set; }

        public string FullName
        {
            get
            {
                return string.Join(" ", FirstName, LastName);
            }
        }
    }
}
