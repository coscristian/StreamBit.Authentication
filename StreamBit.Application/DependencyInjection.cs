using Microsoft.Extensions.DependencyInjection;
using StreamBit.Application.Services.Authentication;

namespace StreamBit.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            return services;
        }
    }
}
