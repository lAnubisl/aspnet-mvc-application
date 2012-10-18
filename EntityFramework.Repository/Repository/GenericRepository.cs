using System;
using System.Data.Entity;
using System.Data.Objects;
using System.Linq;
using Domain.Domain;
using DomainService.RepositoryInterfaces;
using EntityFramework.Repository.EntityFrameworkSession;

namespace EntityFramework.Repository.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IDomainObject
    {
        private DbSet<T> DbSet
        {
            get { return EntityFrameworkSession.Set<T>(); }
        }

        private readonly string sessionFactoryName;

        public GenericRepository(string sessionFactoryName)
        {
            if (string.IsNullOrEmpty(sessionFactoryName))
            {
                throw new ArgumentException("connectionString may not be null nor empty");
            }

            this.sessionFactoryName = sessionFactoryName;
        }

        private Context.Context EntityFrameworkSession
        {
            get
            {
                return EntityFrameworkSessionManager.Instance.GetSessionFrom(sessionFactoryName);
            }
        }

        public IQueryable<T> Query()
        {
            return DbSet;
        }

        public IQueryable<U> Query<U>() where U : IDomainObject
        {
            throw new NotImplementedException();
            //return EntityFrameworkSession.Set<U>();
        }

        public void Delete(T entity)
        {
            DbSet.Remove(entity);
        }

        public void Delete(long id)
        {
            T entity = Get(id);
            if (entity != null)
            {
                Delete(entity);
            }
        }

        public T Save(T entity)
        {
            DbSet.Add(entity);
            EntityFrameworkSession.SaveChanges();
            return entity;
        }

        public T Get(long id)
        {
            return DbSet.SingleOrDefault(x => x.Id == id);
        }

        public T Load(long id)
        {
            return Get(id);
        }
    }
}