using DD.Application.Dto;
using DD.Domain.Model;

namespace DD.Application.Interface
{
    public interface IExampleService
    {
        Task<ExampleModel> AddExampleModelAsync(int id, string name);

        IEnumerable<ExampleModel> GetExampleModels(ExampleModelQueryDto exampleModelDto);
    }
}
