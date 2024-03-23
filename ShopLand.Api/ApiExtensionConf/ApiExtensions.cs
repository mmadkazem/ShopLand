namespace ShopLand.Api.ApiExtensionConf;

internal static class ApiExtensions
{
    internal static IServiceCollection AddApi(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddAuthorizationConf(configuration);
        services.AddSwagger();

        return services;
    }

}