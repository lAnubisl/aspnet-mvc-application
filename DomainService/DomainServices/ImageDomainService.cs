using System.Collections.Generic;
using System.Linq;
using DomainService.DomainModels;
using DomainService.DomainServiceInterfaces;
using DomainService.RepositoryInterfaces;

namespace DomainService.DomainServices
{
    public class ImageDomainService : GenericDomainService<Image, IGenericRepository<Image>>, IImageDomainService
    {
        public IList<Image> LoadByURLs(IEnumerable<string> urls)
        {
            return Repository.Query().Where(x => urls.Contains(x.URL)).ToList();
        }

        public Image LoadByURL(string url)
        {
            return Repository.Query().SingleOrDefault(x => x.URL == url);
        }
    }
}