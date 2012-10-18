using System.Collections.Generic;
using System.Linq;
using DomainService.DomainModels;
using DomainService.DomainServiceInterfaces;
using DomainService.RepositoryInterfaces;

namespace DomainService.DomainServices
{
    public class GenericDomainService<T, TRepository> : IGenericDomainService<T>
        where TRepository : IGenericRepository<T>
        where T : IDomainObject
    {
        public TRepository Repository { get; set; }

        #region IGenericDomainService<T> Members

        public T Load(long id)
        {
            return Repository.Load(id);
        }

        public void Delete(long id)
        {
            Repository.Delete(id);
        }

        public IList<T> Load()
        {
            return Repository.Query().ToList();
        }

        public int Count()
        {
            return Repository.Query().Count();
        }

        public T Save(T entity)
        {
            return Repository.Save(entity);
        }

        public void Delete(T entity)
        {
            Repository.Delete(entity);
        }

        #endregion
    }
}