using UserManagement.Domain.Entities;

namespace UserManagement.EventManager.Events
{
    public class UserCreatedEvent
    {
        public required User User { get; set; }
    }
}