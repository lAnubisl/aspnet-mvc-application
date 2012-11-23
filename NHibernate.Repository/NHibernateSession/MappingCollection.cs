using System.Configuration;

namespace NHibernate.Repository.NHibernateSession
{
    public class MappingCollection : ConfigurationElementCollection
    {
        public MappingCollection()
        {
            AddElementName = "mapping";
        }

        public MappingCollection(string name, string connectionString)
        {
            Name = name;
            ConnectionString = connectionString;
        }

        [ConfigurationProperty("name", IsRequired = true, IsKey = true)]
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