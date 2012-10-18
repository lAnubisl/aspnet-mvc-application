namespace PresentationService.Models.UserModels
{
    internal interface IServiceUser
    {
        string Email { get; }

        string FirstName { get; }

        string LastName { get; }
    }
}