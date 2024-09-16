using MediatR;

namespace Sample.Notifications
{
    public class RandomHandler(ILogger<RandomHandler> logger) : INotificationHandler<ProductCreatedNotification>
    {
        public Task Handle(ProductCreatedNotification notification, CancellationToken cancellationToken)
        {
            logger.LogInformation("Handling notification for product creation with Id : {0}. Performing random action..", notification.Id);

            return Task.CompletedTask;
        }
    }
}
