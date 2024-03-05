using Microsoft.Azure.Cosmos;
using UserManagement.Domain;
using UserManagement.Domain.Repositories;
using AppUser = UserManagement.Domain.Entities.User;
using CosmosContainer = Microsoft.Azure.Cosmos.Container;

namespace UserManagement.Infrastructure
{
    public class UserRepository : IUserRepository
    {
        private readonly CosmosClient _cosmosClient;
        private readonly CosmosContainer _container;

        public UserRepository(string cosmosConnectionString, string databaseName, string containerName)
        {
            _cosmosClient = new CosmosClient(cosmosConnectionString);
            _container = _cosmosClient.GetContainer(databaseName, containerName);
        }

        public async Task CreateUser(AppUser user)
        {
            await _container.CreateItemAsync(user, new PartitionKey(user.Id.ToString()));
        }

        public async Task UpdateUser(AppUser user)
        {
            await _container.UpsertItemAsync(user, new PartitionKey(user.Id.ToString()));
        }

        public async Task DeactivateUser(Guid userId)
        {
            AppUser user = await _container.ReadItemAsync<AppUser>(userId.ToString(), new PartitionKey(userId.ToString()));
            user.Status = UserStatus.Inactive;
            await _container.ReplaceItemAsync(user, userId.ToString(), new PartitionKey(userId.ToString()));
        }
    }
}
