namespace UserManagement.EventManager.Events
{
    public class EventMessage
    {
        public required string EventType { get; set; }
        public required string EventData { get; set; }
    }
}
