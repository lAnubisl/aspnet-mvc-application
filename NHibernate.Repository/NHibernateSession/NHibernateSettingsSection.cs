using System.Configuration;

namespace NHibernate.Repository.NHibernateSession
{
    /// <summary>
    /// Encapsulates a section of Web/App.config to declare which session factories are to be created.
    /// Huge kudos go out to http://msdn2.microsoft.com/en-us/library/system.configuration.configurationcollectionattribute.aspx
    /// for this technique - it was by far the best overview of the subject.
    /// </summary>
    public class NHibernateSettingsSection : ConfigurationSection
    {
        [ConfigurationProperty("sessionFactories", IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(SessionFactoryCollection), AddItemName = "sessionFactory", ClearItemsName = "clearFactories")]
        public SessionFactoryCollection SessionFactory
        {
            get
            {
                var sessionFactoriesCollection = (SessionFactoryCollection)base["sessionFactories"];
                return sessionFactoriesCollection;
            }
        }
    }
}