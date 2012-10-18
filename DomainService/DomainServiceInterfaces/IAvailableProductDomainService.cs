using System;
using System.Collections.Generic;
using DomainService.DomainModels;

namespace DomainService.DomainServiceInterfaces
{
    public interface IAvailableProductDomainService : IGenericDomainService<AvailableProduct>
    {
        IList<AvailableProduct> LoadByUserId(long userId);
        
        IList<AvailableProduct> LoadByCategoryId(long categoryId);

        IList<AvailableProduct> LoadTopProducts(long count, DateTime startDate, DateTime endDate);

        IEnumerable<string> LoadProductNamesForTerm(string term);
    }
}
