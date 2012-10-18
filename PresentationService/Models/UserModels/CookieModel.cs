using DomainService.Enumerations;

namespace PresentationService.Models.UserModels
{
    public class CookieModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public Role Role { get; set; }

        public string FullName
        {
            get
            {
                return string.Join(" ", this.FirstName, LastName);
            }
        }
    }
}
