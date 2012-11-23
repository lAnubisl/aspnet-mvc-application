using System;
using System.Configuration;

namespace NHibernate.Repository.NHibernateSession
{
    [ConfigurationCollection(typeof(MappingCollection))]
    public sealed class SessionFactoryCollection : ConfigurationElementCollection
    {
        public SessionFactoryCollection()
        {
            AddElementName = "sessionFactory";
            var sessionFactory = (MappingCollection)CreateNewElement();
            Add(sessionFactory);
        }

        public override ConfigurationElementCollectionType CollectionType
        {
            get { return ConfigurationElementCollectionType.AddRemoveClearMap; }
        }

        public MappingCollection this[int index]
        {
            get
            {
                return (MappingCollection)BaseGet(index);
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

        public new MappingCollection this[string name]
        {
            get
            {
                return (MappingCollection)BaseGet(name);
            }
        }

        public int IndexOf(MappingCollection sessionFactory)
        {
            return BaseIndexOf(sessionFactory);
        }

        public void Add(MappingCollection sessionFactory)
        {
            BaseAdd(sessionFactory);
        }

        public void Remove(MappingCollection sessionFactory)
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
            return new MappingCollection();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((MappingCollection)element).Name;
        }

        protected override void BaseAdd(ConfigurationElement element)
        {
            BaseAdd(element, false);
        }
    }
}