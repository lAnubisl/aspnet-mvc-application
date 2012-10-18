using System.Configuration;

namespace NHibernate.Repository.NHibernateSession
{
    public class SessionFactoryElement : ConfigurationElementCollection
    {
        public SessionFactoryElement()
        {
            AddElementName = "mapping";
        }

        public SessionFactoryElement(string name, string connectionString)
        {
            Name = name;
            ConnectionString = connectionString;
        }

        [ConfigurationProperty("name", IsRequired = true, IsKey = true, DefaultValue = "rewrwer")]
        public string Name
        {
            get
            {
                return (string)this["name"];
            }

            set
            {
                this["name"] = value;
            }
        }

        [ConfigurationProperty("connectionString", IsRequired = true, DefaultValue = "Default Connection String")]
        public string ConnectionString
        {
            get
            {
                return (string)this["connectionString"];
            }

            set
            {
                this["connectionString"] = value;
            }
        }

        public MappingAssemblyElement this[int index]
        {
            get
            {
                return (MappingAssemblyElement)BaseGet(index);
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

        protected override ConfigurationElement CreateNewElement()
        {
            return new MappingAssemblyElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((MappingAssemblyElement)element).Name;
        }

        protected override void BaseAdd(ConfigurationElement element)
        {
            BaseAdd(element, false);
        }
    }
}