using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Objects;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;

namespace EntityFramework.Repository.EntityFrameworkSession
{
    /// <summary>
    /// Handles creation and management of sessions and transactions. It is a singleton because 
    /// building the initial session factory is very expensive. Inspiration for this class came 
    /// from Chapter 8 of Hibernate in Action by Bauer and King.  Although it is a sealed singleton
    /// you can use TypeMock (http://www.typemock.com) for more flexible testing.
    /// </summary>
    public sealed class EntityFrameworkSessionManager
    {
        private const string SessionKey = "CONTEXT_SESSIONS";

        private readonly Hashtable sessionFactories = new Hashtable();

        /// <summary>
        /// Private constructor to enforce singleton
        /// </summary>
        private EntityFrameworkSessionManager()
        {
        }

        /// <summary>
        /// This is a thread-safe, lazy singleton.  See http://www.yoda.arachsys.com/csharp/singleton.html
        /// for more details about its implementation.
        /// </summary>
        public static EntityFrameworkSessionManager Instance
        {
            get { return Nested.NHibernateSessionManager; }
        }

        /// <summary>
        /// Since multiple databases may be in use, there may be one session per database 
        /// persisted at any one time.  The easiest way to store them is via a hashtable
        /// with the key being tied to session factory.  If within a web context, this uses
        /// <see cref="HttpContext" /> instead of the WinForms specific <see cref="CallContext" />.  
        /// Discussion concerning this found at http://forum.springframework.net/showthread.php?t=572
        /// </summary>
        private Hashtable ContextSessions
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

        //public void AddAssembliesMappings(MappingConfiguration m, SessionFactoryElement sessionFactoryElement)
        //{
        //    for (int i = 0; i < sessionFactoryElement.Count; i++)
        //    {
        //        m.FluentMappings.AddFromAssembly(Assembly.Load(sessionFactoryElement[i].Name));
        //    }
        //}

        /// <summary>
        /// Gets a session.  This method is not called directly; instead,
        /// it gets invoked from other public methods.
        /// </summary>
        public Context.Context GetSessionFrom(string sessionFactoryName)
        {
            var context = (Context.Context)ContextSessions[sessionFactoryName];
            if (context == null)
            {
                context = GetSessionFactoryFor(sessionFactoryName);
                ContextSessions[sessionFactoryName] = context;
            }

            if (context == null)
            {
                throw new NullReferenceException("session was null");
            }

            return context;
        }

        //public void CloseAllSessions()
        //{
        //    foreach (object contextSession in ContextSessions)
        //    {
        //        var session = contextSession as ISession;
        //        if (session != null && session.IsOpen)
        //        {
        //            session.Close();
        //        }
        //    }

        //    ContextSessions.Clear();
        //}

        private Context.Context GetSessionFactoryFor(string sessionFactoryName)
        {
            if (string.IsNullOrEmpty(sessionFactoryName))
            {
                throw new ArgumentException("sessionFactoryConfigPath may not be null nor empty");
            }

            ////  Attempt to retrieve a stored SessionFactory from the hashtable.
            var sessionFactory = (Context.Context)sessionFactories[sessionFactoryName];

            ////  Failed to find a matching SessionFactory so make a new one.
            if (sessionFactory == null)
            {
                sessionFactory = new Context.Context("name=MyDatabaseConnection");

                sessionFactories.Add(sessionFactoryName, sessionFactory);
            }

            return sessionFactory;
        }

        /// <summary>
        /// Assists with ensuring thread-safe, lazy singleton
        /// </summary>
        private class Nested
        {
            internal static readonly EntityFrameworkSessionManager NHibernateSessionManager = new EntityFrameworkSessionManager();
        }
    }
}
