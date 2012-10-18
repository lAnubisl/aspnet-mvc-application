using System;
using System.Configuration;

namespace NHibernate.Repository.NHibernateSession
{
    [ConfigurationCollection(typeof(SessionFactoryElement))]
    public sealed class SessionFactoriesCollection : ConfigurationElementCollection
    {
        public SessionFactoriesCollection()
        {
            AddElementName = "sessionFactory";
            var sessionFactory = (SessionFactoryElement)CreateNewElement();
            Add(sessionFactory);
        }

        public override ConfigurationElementCollectionType CollectionType
        {
            get { return ConfigurationElementCollectionType.AddRemoveClearMap; }
        }

        public SessionFactoryElement this[int index]
        {
            get
            {
                return (SessionFactoryElement)BaseGet(index);
            }

            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }

                BaseAdd(index, value);
            }
        }

        public new SessionFactoryElement this[string name]
        {
            get
            {
                return (SessionFactoryElement)BaseGet(name);
            }
        }

        public int IndexOf(SessionFactoryElement sessionFactory)
        {
            return BaseIndexOf(sessionFactory);
        }

        public void Add(SessionFactoryElement sessionFactory)
        {
            BaseAdd(sessionFactory);
        }

        public void Remove(SessionFactoryElement sessionFactory)
        {
            if (sessionFactory == null)
            {
                throw new ArgumentNullException("sessionFactory");
            }

            if (BaseIndexOf(sessionFactory) >= 0)
            {
                BaseRemove(sessionFactory.Name);
            }
        }

        public void RemoveAt(int index)
        {
            BaseRemoveAt(index);
        }

        public void Remove(string name)
        {
            BaseRemove(name);
        }

        public void Clear()
        {
            BaseClear();
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new SessionFactoryElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((SessionFactoryElement)element).Name;
        }

        protected override void BaseAdd(ConfigurationElement element)
        {
            BaseAdd(element, false);
        }
    }
}