using UserManagement.Domain.Entities;

namespace UserManagement.EventManager.Events
{
    public class UserDeactivatedEvent
    {
        public required IdEntity User { get; set; }
    }
}