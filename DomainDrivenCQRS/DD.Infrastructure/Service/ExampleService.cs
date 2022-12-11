using DD.Application.Dto;
using DD.Application.Interface;
using DD.Domain.Model;

namespace DD.Infrastructure.Service
{
    public class ExampleService : IExampleService
    {
        List<ExampleModel> exampleModels = new();

        public Task<ExampleModel> AddExampleModelAsync(int id, string name)
        {
            var model = new ExampleModel { Id = id, Name = name };
            exampleModels.Add(model);
            return Task.FromResult(model);
        }

        public IEnumerable<ExampleModel> GetExampleModels(ExampleModelQueryDto exampleModelDto)
{
            switch (exampleModelDto.OrderBy)
            {
                case OrderBy.NameAsc:
                    return exampleModels.OrderBy(x => x.Name);
                case OrderBy.NameDesc:
                    return exampleModels.OrderByDescending(x => x.Name);
                case OrderBy.IdAsc:
                    return exampleModels.OrderBy(x => x.Id);
                case OrderBy.IdDesc:
                    return exampleModels.OrderByDescending(x => x.Id);
                default:
                    return exampleModels;
            }
        }
    }
}
