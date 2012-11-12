using System.Collections.Generic;
using DomainService.DomainModels;

namespace DomainService.DomainServiceInterfaces
{
    public interface IImageDomainService : IGenericDomainService<Image>
    {
        IList<Image> LoadByURLs(IEnumerable<string> urls);

        Image LoadByURL(string url);
    }
}