using System;
using System.Collections.Generic;
using System.Linq;
using DomainService.DomainModels;
using DomainService.DomainServiceInterfaces;
using DomainService.RepositoryInterfaces;

namespace DomainService.DomainServices
{
    public class ProductDomainService : GenericDomainService<Product, IGenericRepository<Product>>,
                                        IProductDomainService
    {
        #region IProductDomainService Members

        public IList<Product> LoadByUserId(long userId)
        {
            return Repository.Query().Where(p => p.CreatedBy.Id == userId).ToList();
        }

        public IList<Product> LoadByCategoryId(long categoryId)
        {
            return Repository.Query().Where(p => p.Category.Id == categoryId).ToList();
        }

        public IList<Product> LoadTopProducts(int count, DateTime startDate, DateTime endDate)
        {
            return Repository.Query().Take(count).ToList();
        }

        public Product LoadByName(string name)
        {
            return Repository.Query().SingleOrDefault(x => x.Name == name);
        }

        public IEnumerable<Product> LoadProductsForTerm(string term)
        {
            return Repository.Query().Where(p => p.Name.Contains(term)).ToList();
        }

        #endregion
    }
}