using PresentationService.Models.AdminModels.CategoryModels;

namespace PresentationService.Interfaces.Admin
{
    public interface ICategoryPresentationService : IBasePresentationService
    {
        void SaveCategoryEditModel(CategoryEditModel model);

        CategoryEditModel LoadCategoryEditModel(long categoryId);

        CategoryIndexModel LoadCategoryIndexModel();
    }
}