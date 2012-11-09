using DomainService.DomainModels;
using DomainService.DomainServiceInterfaces;
using DomainService.RepositoryInterfaces;

namespace DomainService.DomainServices
{
    public class ImageDomainService : GenericDomainService<Image, IGenericRepository<Image>>, IImageDomainService
    {
    }
}