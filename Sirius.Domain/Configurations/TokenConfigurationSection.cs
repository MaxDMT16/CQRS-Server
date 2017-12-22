using System.Configuration;

namespace Sirius.Domain.Configurations
{
    public class TokenConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("key")]
        public string Key
        {
            get { return (string) this["key"]; }
            set { this["key"] = value; }
        }
    }
}