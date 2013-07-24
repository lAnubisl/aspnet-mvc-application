using System;
using System.Linq;
using DomainService.DomainModels;
using DomainService.RepositoryInterfaces;
using NHibernate.Linq;
using NHibernate.Repository.NHibernateSession;

namespace NHibernate.Repository.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IDomainObject
    {
        private readonly string connectionString;

        public GenericRepository(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException("connectionString may not be null nor empty");
            }

            this.connectionString = connectionString;
        }

        protected ISession NHibernateSession
        {
            get
            {
                return NHibernateSessionManager.Instance.GetSessionFrom(connectionString);
            }
        }

        #region IGenericRepository<T> Members

        public T Load(long id)
        {
            return NHibernateSession.Get<T>(id);
        }

        public virtual T Save(T entity)
        {
            using (ITransaction transaction = NHibernateSession.BeginTransaction())
            {
                NHibernateSession.Save(entity);
                NHibernateSession.Flush();
                transaction.Commit();
                return entity;
            }
        }

        public virtual void Delete(T entity)
        {
            using (ITransaction transaction = NHibernateSession.BeginTransaction())
            {
                NHibernateSession.Delete(entity);
                NHibernateSession.Flush();
                transaction.Commit();
            }
        }

        public virtual void Delete(long id)
        {
            T entity = Load(id);
            if (entity != null)
            {
                Delete(entity);
            }
        }

        public IQueryable<TCustom> Query<TCustom>() where TCustom : IDomainObject
        {
            return NHibernateSession.Query<TCustom>();
        }

        public IQueryable<T> Query()
        {
            return NHibernateSession.Query<T>();
        }

        #endregion
    }
}