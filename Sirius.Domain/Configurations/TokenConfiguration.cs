namespace Sirius.Domain.Configurations
{
    public class TokenConfiguration
    {
        private readonly TokenConfigurationSection _tokenConfigurationSection;

        public TokenConfiguration(TokenConfigurationSection tokenConfigurationSection)
        {
            _tokenConfigurationSection = tokenConfigurationSection;
        }

        public string Key => _tokenConfigurationSection.Key;
    }
}