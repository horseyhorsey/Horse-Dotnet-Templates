using DD.Application.Dto;
using DD.Application.Interface;
using DD.Domain.Model;
using MediatR;

namespace DD.Application.Features.ExampleModels.Query
{
    public class GetExampleModelsQuery : IRequest<IEnumerable<ExampleModel>>
    {
        public GetExampleModelsQuery(Dto.ExampleModelQueryDto queryDto)
        {
            QueryDto = queryDto;
        }

        public ExampleModelQueryDto QueryDto { get; }
    }

    internal class GetExampleModelsQueryHandler : IRequestHandler<GetExampleModelsQuery, IEnumerable<ExampleModel>>
    {
        private readonly IExampleService exampleService;

        public GetExampleModelsQueryHandler(IExampleService exampleService)
        {
            this.exampleService = exampleService;
        }

        public Task<IEnumerable<ExampleModel>> Handle(GetExampleModelsQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(exampleService.GetExampleModels(request.QueryDto));
        }
    }
}
