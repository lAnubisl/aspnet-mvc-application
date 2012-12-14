using PresentationService.Models.CategoryModels;

namespace PresentationService.Interfaces
{
    public interface ICategoryPresentationService : IBasePresentationService
    {
        CategoryViewModel LoadCategoryViewModel(string seoURL);

        CategoryMenuModel LoadCategoryMenuModel();
    }
}