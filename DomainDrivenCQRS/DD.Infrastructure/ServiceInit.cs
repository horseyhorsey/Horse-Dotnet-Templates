using DD.Application.Interface;
using DD.Infrastructure.Service;
using Microsoft.Extensions.DependencyInjection;

namespace DD.Infrastructure
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IExampleService, ExampleService>();
            return services;
        }
    }
}