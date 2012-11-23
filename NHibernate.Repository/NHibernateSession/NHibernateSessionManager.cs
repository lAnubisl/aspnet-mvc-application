using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Web;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using SessionFactories = System.Collections.Concurrent.ConcurrentDictionary<string, NHibernate.ISessionFactory>;

namespace NHibernate.Repository.NHibernateSession
{
    /// <summary>
    /// Handles creation and management of sessions and transactions. It is a singleton because 
    /// building the initial session factory is very expensive. Inspiration for this class came 
    /// from Chapter 8 of Hibernate in Action by Bauer and King. Although it is a sealed singleton
    /// you can use TypeMock (http://www.typemock.com) for more flexible testing.
    /// </summary>
    public sealed class NHibernateSessionManager
    {
        private const string SessionKey = "CONTEXT_SESSIONS";

        private readonly SessionFactories sessionFactories = new SessionFactories();

        private static readonly Lazy<NHibernateSessionManager> Manager = new Lazy<NHibernateSessionManager>(() => new NHibernateSessionManager(), true);

        /// <summary>
        /// Private constructor to enforce singleton
        /// </summary>
        private NHibernateSessionManager()
        {
        }

        /// <summary>
        /// This is a thread-safe, lazy singleton. See http://csharpindepth.com/articles/general/singleton.aspx
        /// for more details about its implementation.
        /// </summary>
        public static NHibernateSessionManager Instance
        {
            get { return Manager.Value; }
        }

        /// <summary>
        /// Since multiple databases may be in use, there may be one session per database 
        /// persisted at any one time. The easiest way to store them is via a hashtable
        /// with the key being tied to session factory. If within a web context, this uses
        /// <see cref="HttpContext" /> instead of the WinForms specific <see cref="CallContext" />.  
        /// Discussion concerning this found at http://forum.springframework.net/showthread.php?t=572
        /// </summary>
        private static Hashtable ContextSessions
        {
            get
            {
                if (HttpContext.Current.Items[SessionKey] == null)
                {
                    HttpContext.Current.Items[SessionKey] = new Hashtable();
                }

                return (Hashtable)HttpContext.Current.Items[SessionKey];
            }
        }

        public static void AddAssembliesMappings(MappingConfiguration mapping, MappingCollection mappingCollectionElement)
        {
            if (mapping == null)
            {
                throw new ArgumentNullException("mapping");
            }

            if (mappingCollectionElement == null)
            {
                throw new ArgumentNullException("mappingCollectionElement");
            }

            for (var i = 0; i < mappingCollectionElement.Count; i++)
            {
                mapping.FluentMappings.AddFromAssembly(Assembly.Load(mappingCollectionElement[i].Name));
            }
        }

        public static void CloseAllSessions()
        {
            foreach (var contextSession in ContextSessions)
            {
                var session = ((DictionaryEntry)contextSession).Value as ISession;
                if (session != null && session.IsOpen)
                {
                    session.Close();
                }
            }

            ContextSessions.Clear();
        }

        /// <summary>
        /// Gets a session.  This method is not called directly; instead,
        /// it gets invoked from other public methods.
        /// </summary>
        public ISession GetSessionFrom(string sessionFactoryName)
        {
            var session = (ISession)ContextSessions[sessionFactoryName];
            if (session == null)
            {
                session = GetSessionFactoryFor(sessionFactoryName).OpenSession();
                session.FlushMode = FlushMode.Never;
                ContextSessions[sessionFactoryName] = session;
            }

            return session;
        }

        private static MappingCollection GetSessionFactorySettings(string sessionFactoryName)
        {
            var settingsSection = ConfigurationManager.GetSection("nhibernateSettings") as NHibernateSettingsSection;

            if (settingsSection != null)
            {
                return settingsSection.SessionFactory[sessionFactoryName];
            }

            return null;
        }

        private ISessionFactory GetSessionFactoryFor(string sessionFactoryName)
        {
            if (string.IsNullOrEmpty(sessionFactoryName))
            {
                throw new ArgumentException("sessionFactoryConfigPath may not be null nor empty");
            }

            ////  Attempt to retrieve a stored SessionFactory from the hashtable.
            ISessionFactory sessionFactory;

            sessionFactories.TryGetValue(sessionFactoryName, out sessionFactory);

            ////  Failed to find a matching SessionFactory so make a new one.
            if (sessionFactory == null)
            {
                var sectionFactorySettings = GetSessionFactorySettings(sessionFactoryName);

                sessionFactory = Fluently.Configure()
                    .Mappings(m => AddAssembliesMappings(m, sectionFactorySettings))
                    .Database(
                        MsSqlConfiguration.MsSql2008
                            .ConnectionString(sectionFactorySettings.ConnectionString)
                            .ShowSql()
                            .DefaultSchema("dbo")
                            .IsolationLevel(IsolationLevel.ReadCommitted))
                    .BuildSessionFactory();

                if (sessionFactory == null)
                {
                    throw new InvalidOperationException("session factory is null");
                }

                sessionFactories.TryAdd(sessionFactoryName, sessionFactory);
            }

            return sessionFactory;
        }
    }
}