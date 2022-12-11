using DD.Application;
using DD.Application.Dto;
using DD.Application.Features.ExampleModels.Behaviors;
using DD.Application.Features.ExampleModels.Cmd;
using DD.Application.Features.ExampleModels.Query;
using DD.Application.Interface;
using DD.Infrastructure;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DD.ConsoleHost
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //build a host with our services
            using IHost host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((x, services) =>
                    services.AddApplication().AddInfrastructure()
                    .AddSingleton(typeof(IPipelineBehavior<,>),typeof(LogBehavior<,>)))
                .Build();

            //create a scope and get provider
            using IServiceScope serviceScope = host.Services.CreateScope();
            IServiceProvider provider = serviceScope.ServiceProvider;

            //get mediator interface
            IMediator mediator = provider.GetRequiredService<IMediator>();

            Console.WriteLine("adding Dave");
            var cmd = new AddExampleModelCmd(new ExampleModelCmdDto(28, "Dave"));
            await mediator.Send(cmd);

            Console.WriteLine("adding Horse");
            cmd = new AddExampleModelCmd(new ExampleModelCmdDto(29, "Horse"));
            await mediator.Send(cmd);

            //get added models and print
            var query = new GetExampleModelsQuery(new ExampleModelQueryDto() { OrderBy = OrderBy.NameDesc });            
            var results = await mediator.Send(query);
            foreach (var result in results)
            {
                Console.WriteLine($"loop result: {result.Id} {result.Name}");
            }

            await host.RunAsync();
        }
    }
}