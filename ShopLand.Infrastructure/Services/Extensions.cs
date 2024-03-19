using ShopLand.Infrastructure.Services.DbInitializer;
using ShopLand.Infrastructure.Services.JwtToken;

namespace ShopLand.Infrastructure.Services;

public static class Extensions
{
    internal static IServiceCollection AddExternalServices(this IServiceCollection services)
    {
        services.AddTransient<ITokenFactoryService, TokenFactoryService>();
        services.AddSingleton<IDbInitializerService, DbInitializerService>();
        return services;
    }
}