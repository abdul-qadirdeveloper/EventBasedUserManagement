using UserManagement.Domain.Entities;

namespace UserManagement.EventManager.Events
{
    public class UserUpdatedEvent
    {
        public required User User { get; set; }
    }
}