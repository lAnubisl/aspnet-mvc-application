using System.ComponentModel.DataAnnotations;
using PresentationService.Resources;
using PresentationService.ValidationAttributes;

namespace PresentationService.Models.UserModels
{
    public class RegisterUserModel
    {
        public RegisterUserModel()
        {
        }

        [Display(Name = "UserEmail", ResourceType = typeof(EntityNames)), CommonStringLength(255), CommonRequired, CommonEmailRegex, IsUniqueEmail]
        public string Email { get; set; }
    }
}