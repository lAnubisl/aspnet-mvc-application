using System.Linq;
using DomainService.DomainModels;

namespace DomainService.RepositoryInterfaces
{
    public interface IGenericRepository<T> where T : IDomainObject
    {
        IQueryable<T> Query();

        IQueryable<TCustom> Query<TCustom>() where TCustom : IDomainObject;

        void Delete(T entity);

        void Delete(long id);

        T Save(T entity);

        T Load(long id);
    }
}