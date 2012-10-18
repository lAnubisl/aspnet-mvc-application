using System.Configuration;

namespace NHibernate.Repository.NHibernateSession
{
    public class MappingAssemblyElement : ConfigurationElement
    {
        public MappingAssemblyElement()
        {
        }

        public MappingAssemblyElement(string name)
        {
            Name = name;
        }

        [ConfigurationProperty("name", IsRequired = true, IsKey = true, DefaultValue = "Default Name")]
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
    }
}