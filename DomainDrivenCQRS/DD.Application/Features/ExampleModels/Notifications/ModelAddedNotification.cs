using DD.Domain.Model;
using MediatR;

namespace DD.Application.Features.ExampleModels.Notifications
{
    public record ModelAddedNotification : INotification
    {
        public ModelAddedNotification(ExampleModel model) => Model = model;
        public ExampleModel Model { get; }
    }

    public class ConsoleWriteHandler : INotificationHandler<ModelAddedNotification>
    {
        public async Task Handle(ModelAddedNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"{notification.Model.Id} {notification.Model.Name} was added notification");
            await Task.CompletedTask;
        }
    }
}
