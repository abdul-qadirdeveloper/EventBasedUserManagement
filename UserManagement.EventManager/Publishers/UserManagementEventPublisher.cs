
using Newtonsoft.Json;
using UserManagement.EventManager.Events;

namespace UserManagement.EventManager.Publishers
{
    public abstract class UserManagementEventPublisher : IUserManagementEventPublisher
    {
        public async Task PublishUserCreated(UserCreatedEvent userCreatedEvent)
        {
            EventMessage eventMessage = new EventMessage
            {
                EventType = userCreatedEvent.GetType().Name,
                EventData = JsonConvert.SerializeObject(userCreatedEvent)
            };
            await PublishEvent(eventMessage);
        }

        public async Task PublishUserUpdated(UserUpdatedEvent userUpdatedEvent)
        {
            EventMessage eventMessage = new EventMessage
            {
                EventType = userUpdatedEvent.GetType().Name,
                EventData = JsonConvert.SerializeObject(userUpdatedEvent)
            };
            await PublishEvent(eventMessage);
        }

        public async Task PublishUserDeactivated(UserDeactivatedEvent userDeactivatedEvent)
        {
            EventMessage eventMessage = new EventMessage
            {
                EventType = userDeactivatedEvent.GetType().Name,
                EventData = JsonConvert.SerializeObject(userDeactivatedEvent)
            };
            await PublishEvent(eventMessage);
        }

        public abstract Task PublishEvent(EventMessage eventMessage);
    }
}
