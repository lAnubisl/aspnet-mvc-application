using System.ComponentModel;
using PresentationService.ValidationAttributes;

namespace PresentationService.Models.UserModels
{
    public class RegisterUserModel
    {
        [DisplayName("Email"), CommonStringLength(255), CommonRequired, CommonEmailRegex, IsUniqueEmail]
        public string Email { get; set; }
    }
}