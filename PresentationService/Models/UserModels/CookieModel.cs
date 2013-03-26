using System;
using DomainService.DomainModels;
using DomainService.Enumerations;

namespace PresentationService.Models.UserModels
{
    public class CookieModel
    {
        private readonly string firstName, lastName, email;
        private readonly Role role;

        internal CookieModel(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            this.firstName = user.FirstName;
            this.lastName = user.LastName;
            this.email = user.Email;
            this.role = user.Role;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
        }

        public string Email
        {
            get
            {
                return this.email;
            }
        }

        public Role Role
        {
            get
            {
                return this.role;
            }
        }

        public string FullName
        {
            get
            {
                return string.Join(" ", FirstName, LastName);
            }
        }
    }
}
