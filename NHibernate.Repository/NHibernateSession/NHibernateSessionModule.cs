using System;
using System.Web;

namespace NHibernate.Repository.NHibernateSession
{
    public class NHibernateSessionModule : IHttpModule
    {
        #region IHttpModule Members

        public void Init(HttpApplication context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            context.EndRequest += CloseAllNHibernateSessions;
        }

        public void Dispose()
        {
        }

        #endregion

        private void CloseAllNHibernateSessions(object sender, EventArgs e)
        {
            NHibernateSessionManager.CloseAllSessions();
        }
    }
}