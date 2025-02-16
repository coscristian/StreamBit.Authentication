using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StreamBit.Application.Common.Interfaces.Authentication;
using StreamBit.Application.Common.Interfaces.Persistence;
using StreamBit.Application.Common.Interfaces.Services;
using StreamBit.Infrastructure.Authentication;
using StreamBit.Infrastructure.Persistence;
using StreamBit.Infrastructure.Services;

namespace StreamBit.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configurationManager)
    {
        services.Configure<JwtSettings>(configurationManager.GetSection(JwtSettings.SectionName));
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }

}
