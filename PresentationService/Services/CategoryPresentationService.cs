using System.Linq;
using DomainService.DomainServiceInterfaces;
using PresentationService.Interfaces;
using PresentationService.Models.CategoryModels;
using PresentationService.Models.CategoryModels.Items;
using PresentationService.Models.ProductModels;

namespace PresentationService.Services
{
    public class CategoryPresentationService : ICategoryPresentationService
    {
        private readonly IAvailableProductDomainService productDomainService;
        private readonly ICategoryDomainService categoryDomainService;

        public CategoryPresentationService(IAvailableProductDomainService productDomainService, ICategoryDomainService categoryDomainService)
        {
            this.productDomainService = productDomainService;
            this.categoryDomainService = categoryDomainService;
        }

        public CategoryViewModel LoadCategoryViewModel(long categoryId)
        {
            var category = categoryDomainService.Load(categoryId);
            if (category != null)
            {
                var products = productDomainService.LoadByCategoryId(categoryId);
                var model = new CategoryViewModel(
                    category.Name,
                    category.Description,
                    products.Select(p => new ProductSmallModel(p.Id, p.Price, p.Name)),
                    category.ChildCategories.Select(c => new CategoryListElementModel(c.Name, c.Id)));
                return model;
            }

            return null;
        }

        public CategoryMenuModel LoadCategoryMenuModel()
        {
            return
                new CategoryMenuModel(
                    categoryDomainService.LoadRootCategories().Select(c =>
                        new CategoryMenuElementModel(
                            c.Name, 
                            c.Id, 
                            c.ChildCategories.Select(cc => new CategoryMenuElementModel(
                                cc.Name, 
                                cc.Id, 
                                null)))));
        }
    }
}