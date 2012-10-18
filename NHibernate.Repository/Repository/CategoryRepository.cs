using System;
using System.Collections.Generic;
using DomainService.DomainModels;
using DomainService.RepositoryInterfaces;
using NHibernate.Repository.NHibernateSession;

namespace NHibernate.Repository.Repository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly string sessionFactoryName;

        public CategoryRepository(string sessionFactoryName) : base(sessionFactoryName)
        {
            if (string.IsNullOrEmpty(sessionFactoryName))
            {
                throw new ArgumentException("connectionString may not be null nor empty");
            }

            this.sessionFactoryName = sessionFactoryName;
        }

        #region ICategoryRepository Members

        private ISession NHibernateSession
        {
            get
            {
                return NHibernateSessionManager.Instance.GetSessionFrom(sessionFactoryName);
            }
        }

        public IList<Category> LoadDependencySaveParentsForCategoryId(long categoryId)
        {
            //// Run stored procedure
            return NHibernateSession.CreateSQLQuery("exec parent_categories_for_categoryId ?")
                .AddEntity(typeof(Category)).SetInt64(0, categoryId).List<Category>();
            //// AddEntity tells NHhibernate that query result must be converted to Category entity
        }

        #endregion
    }
}