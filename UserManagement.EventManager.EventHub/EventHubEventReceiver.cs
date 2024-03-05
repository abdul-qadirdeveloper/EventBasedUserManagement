using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Processor;
using Azure.Storage.Blobs;
using Newtonsoft.Json;
using System.Text;
using UserManagement.EventManager.Events;

namespace UserManagement.EventManager.Consumers
{
    public class EventHubEventReceiver
    {
        private readonly IUserManagementEventConsumer _eventConsumer;

        public EventHubEventReceiver(IUserManagementEventConsumer eventConsumer)
        {
            _eventConsumer = eventConsumer;
        }

        public async Task StartReceiving()
        {
            string connectionString = "<event-hubs-connection-string>";
            string eventHubName = "<event-hub-name>";
            string blobStorageConnectionString = "<blob-storage-connection-string>";
            string blobContainerName = "<blob-container-name>";

            BlobContainerClient storageClient = new BlobContainerClient(blobStorageConnectionString, blobContainerName);
            EventProcessorClient processor = new EventProcessorClient(storageClient, EventHubConsumerClient.DefaultConsumerGroupName, connectionString, eventHubName);

            processor.ProcessEventAsync += ProcessEventHandler;
            processor.ProcessErrorAsync += ProcessErrorHandler;

            await processor.StartProcessingAsync();
        }

        private Task ProcessEventHandler(ProcessEventArgs eventArgs)
        {
            string message = Encoding.UTF8.GetString(eventArgs.Data.Body.ToArray());
            var eventMessage = JsonConvert.DeserializeObject<EventMessage>(message);
            if (eventMessage != null)
            {
                Type? eventType = Type.GetType(eventMessage.EventType);

                object? eventObject = JsonConvert.DeserializeObject(eventMessage.EventData, eventType!);
                if (eventObject is UserCreatedEvent)
                {
                    _eventConsumer.ConsumeUserCreated((UserCreatedEvent)eventObject);
                }
                else if (eventObject is UserDeactivatedEvent)
                {
                    _eventConsumer.ConsumeUserDeactivated((UserDeactivatedEvent)eventObject);
                }
                else if (eventObject is UserUpdatedEvent)
                {
                    _eventConsumer.ConsumeUserUpdated((UserUpdatedEvent)eventObject);
                }
            }

            return Task.CompletedTask;
        }

        private Task ProcessErrorHandler(ProcessErrorEventArgs eventArgs)
        {
            // Here you would handle any errors that occur during processing
            return Task.CompletedTask;
        }
    }
}
