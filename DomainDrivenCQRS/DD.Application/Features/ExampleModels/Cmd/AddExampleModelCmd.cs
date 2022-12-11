using DD.Application.Dto;
using DD.Application.Features.ExampleModels.Notifications;
using DD.Application.Interface;
using MediatR;

namespace DD.Application.Features.ExampleModels.Cmd
{
    public class AddExampleModelCmd : IRequest
    {
        public AddExampleModelCmd(ExampleModelCmdDto modelCmdDto)
        {
            ModelCmdDto = modelCmdDto;
        }

        public ExampleModelCmdDto ModelCmdDto { get; }
    }

    internal class AddExampleModelCmdHandler : IRequestHandler<AddExampleModelCmd>
    {
        private readonly IExampleService exampleService;
        private readonly IMediator mediator;

        public AddExampleModelCmdHandler(IExampleService exampleService, IMediator mediator)
        {
            this.exampleService = exampleService;
            this.mediator = mediator;
        }

        public async Task<Unit> Handle(AddExampleModelCmd request, CancellationToken cancellationToken)
        {
            if (!cancellationToken.IsCancellationRequested)
            {
                var model = await exampleService.AddExampleModelAsync(request.ModelCmdDto.Id, request.ModelCmdDto.Name);
                await mediator.Publish(new ModelAddedNotification(model), cancellationToken);
            }

            return Unit.Value;
        }
    }
}
