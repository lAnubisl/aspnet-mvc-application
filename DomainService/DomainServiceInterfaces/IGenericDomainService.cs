using System.Collections.Generic;
using DomainService.DomainModels;

namespace DomainService.DomainServiceInterfaces
{
    public interface IGenericDomainService<T> where T : IDomainObject
    {
        /// <summary>
        /// Load entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T Load(long id);

        /// <summary>
        /// Delete entity by id
        /// </summary>
        /// <param name="id"></param>
        void Delete(long id);

        /// <summary>
        /// Load all entities
        /// </summary>
        /// <returns></returns>
        IList<T> Load();

        /// <summary>
        /// Load count of all entities
        /// </summary>
        /// <returns></returns>
        int Count();

        /// <summary>
        /// Saves entity to database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        T Save(T entity);

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="entity"></param>
        void Delete(T entity);
    }
}