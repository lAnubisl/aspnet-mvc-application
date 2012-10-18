using System;
using System.Collections.Generic;
using DomainService.DomainModels;

namespace DomainService.DomainServiceInterfaces
{
    public interface IProductDomainService : IGenericDomainService<Product>
    {
        /// <summary>
        /// Load products created by this user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        IList<Product> LoadByUserId(long userId);

        /// <summary>
        /// Load products assigned to category
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        IList<Product> LoadByCategoryId(long categoryId);

        IList<Product> LoadTopProducts(int count, DateTime startDate, DateTime endDate);

        Product LoadByName(string name);
            
        IEnumerable<Product> LoadProductsForTerm(string term);
    }
}