using MediatR;

namespace Sample.Notifications
{
    public class StockAssignedHandler(ILogger<StockAssignedHandler> logger) : INotificationHandler<ProductCreatedNotification>
    {
        public Task Handle(ProductCreatedNotification notification, CancellationToken cancellationToken)
        {
            logger.LogInformation("Handling notification for product creation with Id : {0}. Assigning stocks.", notification.Id);
            return Task.CompletedTask;
        }
    }
}
