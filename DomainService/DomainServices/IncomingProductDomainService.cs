using DomainService.DomainModels;
using DomainService.DomainServiceInterfaces;
using DomainService.RepositoryInterfaces;

namespace DomainService.DomainServices
{
    public class IncomingProductDomainService : GenericDomainService<IncomingProduct, IGenericRepository<IncomingProduct>>,
                                                IIncomingProductDomainService
    {
    }
}
