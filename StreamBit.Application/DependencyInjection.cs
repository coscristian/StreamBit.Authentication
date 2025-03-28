using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace StreamBit.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(configuration =>
                configuration.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly())
            );
            
            return services;
        }
    }
}
