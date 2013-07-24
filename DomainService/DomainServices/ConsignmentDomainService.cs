using System.Collections.Generic;
using System.Linq;
using DomainService.DomainModels;
using DomainService.DomainServiceInterfaces;
using DomainService.RepositoryInterfaces;

namespace DomainService.DomainServices
{
    public class ConsignmentDomainService : GenericDomainService<Consignment, IGenericRepository<Consignment>>, IConsignmentDomainService
    {
        public ConsignmentDomainService(IGenericRepository<Consignment> repository) : base(repository)
        {
        }

        public new IList<Consignment> Load()
        {
            return Repository.Query().OrderByDescending(c => c.CreationDate).ToList();
        } 
    }
}
