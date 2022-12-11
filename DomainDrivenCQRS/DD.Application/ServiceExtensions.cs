using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace DD.Application
{
    /// <summary>
    /// Service Collection Extensions
    /// </summary>
    public static class ServiceExtensions
    {
        /// <summary>
        /// AddMediatR and any other you need
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            return services;
        }
    }
}