using ShopLand.Application.RequestPays.Facade;

namespace ShopLand.Application.RequestPays;

public static class Extensions
{
    internal static IServiceCollection AddProduct(this IServiceCollection services)
    {
        // DI Account Commands and Queries Handlers
        services.AddTransient<ICreateRequestPayCommandHandler, CreateRequestPayCommandHandler>();
        services.AddTransient<IGetRequestPayQueryHandler, GetRequestPayQueryHandler>();
        services.AddTransient<IGetRequestPaysUserQueryHandler, GetRequestPaysUserQueryHandler>();

        // DI Account Facade
        services.AddTransient<IRequestPayFacade, RequestPayFacade>();

        return services;
    }
}