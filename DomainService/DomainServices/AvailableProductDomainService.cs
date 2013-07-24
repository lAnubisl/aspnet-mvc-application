using System.Collections.Generic;
using System.Linq;
using DomainService.DomainModels;
using DomainService.DomainServiceInterfaces;
using DomainService.RepositoryInterfaces;

namespace DomainService.DomainServices
{
    public class AvailableProductDomainService : GenericDomainService<AvailableProduct, IGenericRepository<AvailableProduct>>, IAvailableProductDomainService
    {
        public AvailableProductDomainService(IGenericRepository<AvailableProduct> repository) : base(repository)
        {
        }

        public IList<AvailableProduct> LoadByUserId(long userId)
        {
            return Repository.Query().Where(p => p.CreatedBy.Id == userId).ToList();
        }

        public IList<AvailableProduct> LoadByCategoryId(long categoryId)
        {
            return Repository.Query().Where(p => p.CreatedBy.Id == categoryId).ToList();
        }

        public IList<AvailableProduct> LoadTopProducts(long count, System.DateTime startDate, System.DateTime endDate)
        {
            return Repository.Query().Take((int)count).ToList();
        }

        public IEnumerable<string> LoadProductNamesForTerm(string term)
        {
            return Repository.Query().Where(p => p.Name.Contains(term)).Select(p => p.Name).ToList();
        }
    }
}