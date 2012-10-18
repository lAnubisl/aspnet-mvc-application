using PresentationService.Models.UserModels;

namespace PresentationService.Interfaces
{
    public interface IUserPresentationService : IBasePresentationService
    {
        CookieModel LoadCookieModel(string email);

        CookieModel LoadCookieModel(LogOnService service, string accessToken);

        bool ValidatePassword(LogOnUserModel model);

        bool RegisterNewUser(RegisterUserModel model);
    }
}