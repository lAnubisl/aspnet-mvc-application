using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using DomainService.Enumerations;
using PresentationService.ValidationAttributes;

namespace PresentationService.Models.AdminModels.UserModels
{
    public class UserEditModel
    {
        public long UserId { get; set; }

        [DisplayName("Имя"), CommonRequired, CommonStringLength(50)]
        public string FirstName { get; set; }

        [DisplayName("Фамилия"), CommonRequired, CommonStringLength(50)]
        public string LastName { get; set; }

        [DisplayName("Роль"), Required]
        public Role Role { get; set; }

        [Required, UserShouldHaveUniqueEmail, CommonEmailRegex]
        public string Email { get; set; }
    }
}
