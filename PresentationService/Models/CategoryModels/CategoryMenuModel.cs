using System.Collections.Generic;
using PresentationService.Models.CategoryModels.Items;

namespace PresentationService.Models.CategoryModels
{
    public class CategoryMenuModel
    {
        public CategoryMenuModel(IEnumerable<CategoryMenuElementModel> rootCategories)
        {
            RootCategories = rootCategories;
        }

        public IEnumerable<CategoryMenuElementModel> RootCategories { get; private set; } 
    }
}
