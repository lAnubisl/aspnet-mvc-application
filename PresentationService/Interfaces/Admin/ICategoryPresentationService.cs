using PresentationService.Models.AdminModels.CategoryModels;

namespace PresentationService.Interfaces.Admin
{
    public interface ICategoryPresentationService : IBasePresentationService
    {
        bool CanBeDeleted(long categoryId);

        void DeleteCategory(long categoryId);

        void SaveCategoryEditModel(CategoryEditModel model);

        CategoryEditModel LoadCategoryEditModel(long categoryId);

        CategoryIndexModel LoadCategoryIndexModel();
    }
}