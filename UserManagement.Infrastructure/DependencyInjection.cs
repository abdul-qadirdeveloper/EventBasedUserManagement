using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserManagement.Domain.Repositories;

namespace UserManagement.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration, Func<string, string?> configReader)
        {
            // Add CosmosDB configuration
            var cosmosDbConnectionString = configuration.GetConnectionString("CosmosDb");
            var databaseName = configReader("CosmosDb:DatabaseName");
            var containerName = configReader("CosmosDb:ContainerName");

            // Add UserRepository
            services.AddSingleton<IUserRepository>(new UserRepository(cosmosDbConnectionString, databaseName, containerName));
            return services;
        }
    }
}
