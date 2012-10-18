using System.Diagnostics.CodeAnalysis;
using DomainService.DomainModels;

namespace DomainService.DomainServiceInterfaces
{
    [SuppressMessage("Microsoft.Design", "CA1040:AvoidEmptyInterfaces", Justification = "This interface is used by dependency injection.")]
    public interface IIncomingProductDomainService : IGenericDomainService<IncomingProduct>
    {
    }
}
