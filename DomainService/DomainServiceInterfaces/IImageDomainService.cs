using System.Collections.Generic;
using DomainService.DomainModels;

namespace DomainService.DomainServiceInterfaces
{
    public interface IImageDomainService : IGenericDomainService<Image>
    {
        IList<Image> LoadByUrls(IEnumerable<string> urls);

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "0#", Justification = "url is a string property representation of database field")]
        Image LoadByUrl(string url);
    }
}