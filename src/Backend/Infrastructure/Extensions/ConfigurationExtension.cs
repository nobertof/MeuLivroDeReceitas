

using Microsoft.Extensions.Configuration;

namespace Infrastructure.Extensions
{
    public static class ConfigurationExtension
    {
        public static string ConnectionString(this IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Connection");

            return connectionString!;
        }
    }
}