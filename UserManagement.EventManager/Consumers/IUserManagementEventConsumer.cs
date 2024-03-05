using UserManagement.EventManager.Events;

namespace UserManagement.EventManager.Consumers
{
    public interface IUserManagementEventConsumer
    {
        Task ConsumeUserCreated(UserCreatedEvent userCreatedEvent);
        Task ConsumeUserUpdated(UserUpdatedEvent userUpdatedEvent);
        Task ConsumeUserDeactivated(UserDeactivatedEvent userDeactivatedEvent);
    }
}


