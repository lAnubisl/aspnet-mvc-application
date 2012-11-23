using System.Collections.Generic;
using System.Linq;
using DomainService.DomainModels;
using DomainService.DomainServiceInterfaces;
using DomainService.RepositoryInterfaces;

namespace DomainService.DomainServices
{
    public class ImageDomainService : GenericDomainService<Image, IGenericRepository<Image>>, IImageDomainService
    {
        public IList<Image> LoadByUrls(IEnumerable<string> urls)
        {
            return Repository.Query().Where(x => urls.Contains(x.Url)).ToList();
        }

        public Image LoadByUrl(string url)
        {
            return Repository.Query().SingleOrDefault(x => x.Url == url);
        }
    }
}