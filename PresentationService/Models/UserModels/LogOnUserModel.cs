using System.ComponentModel.DataAnnotations;
using PresentationService.ValidationAttributes;

namespace PresentationService.Models.UserModels
{
    public class LogOnUserModel
    {
        public LogOnUserModel()
        {
        }

        [Required]
        [PasswordValidation]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
