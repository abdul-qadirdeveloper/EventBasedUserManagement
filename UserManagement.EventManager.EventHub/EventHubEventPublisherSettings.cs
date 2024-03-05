namespace UserManagement.EventManager.EventHub
{
    public class EventHubEventPublisherSettings
    {
        public string ConnectionString { get; internal set; }
        public string EventHubName { get; internal set; }
    }
}