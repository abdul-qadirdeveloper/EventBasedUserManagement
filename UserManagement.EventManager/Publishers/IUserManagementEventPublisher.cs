using UserManagement.EventManager.Events;

namespace UserManagement.EventManager.Publishers
{
    public interface IUserManagementEventPublisher
    {
        Task PublishEvent(EventMessage eventMessage);
        Task PublishUserCreated(UserCreatedEvent userCreatedEvent);
        Task PublishUserDeactivated(UserDeactivatedEvent userDeactivatedEvent);
        Task PublishUserUpdated(UserUpdatedEvent userUpdatedEvent);
    }
}