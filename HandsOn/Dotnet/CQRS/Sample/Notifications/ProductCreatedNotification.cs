using MediatR;

namespace Sample.Notifications
{
    public record ProductCreatedNotification(Guid Id) : INotification;
}
