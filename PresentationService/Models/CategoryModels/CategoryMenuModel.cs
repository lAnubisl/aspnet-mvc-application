using System;
using System.Collections.Generic;
using System.Linq;
using DomainService.DomainModels;
using PresentationService.Models.CategoryModels.Items;

namespace PresentationService.Models.CategoryModels
{
    public class CategoryMenuModel
    {
        private readonly IEnumerable<CategoryMenuElementModel> rootCategories;

        internal CategoryMenuModel(IEnumerable<Category> rootCategories)
        {
            if (rootCategories == null)
            {
                throw new ArgumentNullException("rootCategories");
            }

            this.rootCategories = rootCategories.Select(c => new CategoryMenuElementModel(c, c.ChildCategories));
        }

        public IEnumerable<CategoryMenuElementModel> RootCategories 
        { 
            get 
            { 
                return this.rootCategories; 
            } 
        } 
    }
}