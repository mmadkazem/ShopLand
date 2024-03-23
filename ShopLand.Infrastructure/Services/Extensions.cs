namespace ShopLand.Infrastructure.Services;

public static class Extensions
{
    internal static IServiceCollection AddExternalServices(this IServiceCollection services)
    {
        services.AddTransient<ITokenFactoryService, TokenFactoryService>();
        services.AddScoped<ITokenValidatorService, TokenValidatorService>();
        services.AddSingleton<IDbInitializerService, DbInitializerService>();
        return services;
    }
}