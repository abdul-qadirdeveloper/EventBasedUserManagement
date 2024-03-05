using UserManagement.Application.ConsumerApiStub;
using UserManagement.EventManager.Events;

namespace UserManagement.EventManager.Consumers
{
    public class UserManagementEventConsumer : IUserManagementEventConsumer
    {
        private readonly IUserClient userClient;

        public UserManagementEventConsumer(IUserClient userClient)
        {
            this.userClient = userClient;
        }
        public async Task ConsumeUserCreated(UserCreatedEvent userCreatedEvent)
        {
            await userClient.CreateUserAsync(userCreatedEvent.User);
        }

        public async Task ConsumeUserDeactivated(UserDeactivatedEvent userDeactivatedEvent)
        {
            await userClient.DeactivateUserAsync(userDeactivatedEvent.User.Id);
        }

        public async Task ConsumeUserUpdated(UserUpdatedEvent userUpdatedEvent)
        {
            await userClient.UpdateUserAsync(userUpdatedEvent.User);
        }
    }
}

