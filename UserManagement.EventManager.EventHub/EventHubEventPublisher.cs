using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Producer;
using Newtonsoft.Json;
using System.Text;
using UserManagement.EventManager.Events;
using UserManagement.EventManager.Publishers;

namespace UserManagement.EventManager.EventHub
{
    public class EventHubEventPublisher : UserManagementEventPublisher
    {
        private readonly EventHubEventPublisherSettings settings;

        public EventHubEventPublisher(EventHubEventPublisherSettings settings)
        {
            this.settings = settings;
        }
        public override async Task PublishEvent(EventMessage eventMessage)
        {

            var options = new EventHubProducerClientOptions
            {
                RetryOptions = new EventHubsRetryOptions
                {
                    Mode = EventHubsRetryMode.Fixed,
                    MaximumRetries = 5,
                    Delay = TimeSpan.FromSeconds(1),
                    MaximumDelay = TimeSpan.FromSeconds(30),
                    TryTimeout = TimeSpan.FromSeconds(1)
                }
            };
            await using (var producerClient = new EventHubProducerClient(settings.ConnectionString, settings.EventHubName, options))
            {
                string message = JsonConvert.SerializeObject(eventMessage);
                EventData eventData = new EventData(Encoding.UTF8.GetBytes(message));

                try
                {
                    await producerClient.SendAsync(new[] { eventData });
                }
                catch (EventHubsException e) when (e.Reason == EventHubsException.FailureReason.ClientClosed)
                {
                    // Handle a specific type of Event Hubs exception
                }
                catch (Exception e)
                {
                    // Handle other exceptions
                }
            }
        }
    }
}
