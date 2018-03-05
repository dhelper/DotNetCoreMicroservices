using LunchService.Accessors;
using Microsoft.Extensions.Options;

namespace LunchService
{
    public class ConfigurationBasedConnectionString : IConnectionStringProvider
    {
        private readonly IOptions<ConnectionStrings> _options;

        public ConfigurationBasedConnectionString(IOptions<ConnectionStrings> options)
        {
            _options = options;
        }

        public string GetConnectionString()
        {
            return _options.Value.DefaultConnection;
        }
    }
}