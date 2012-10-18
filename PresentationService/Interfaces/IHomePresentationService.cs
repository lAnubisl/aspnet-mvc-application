using PresentationService.Models.HomeModels;

namespace PresentationService.Interfaces
{
    public interface IHomePresentationService : IBasePresentationService
    {
        HomeIndexModel LoadHomeIndexModel();
    }
}