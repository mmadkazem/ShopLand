namespace ShopLand.Application.Carts;

public static class Extension
{
    public static IServiceCollection AddCarts(this IServiceCollection services)
    {
        // DI Cart Commands and Queries Handlers
        services.AddTransient<IAddCartItemCommandHandler, AddCartItemCommandHandler>();
        services.AddTransient<IUpdateCartItemCommandHandler, UpdateCartItemCommandHandler>();
        services.AddTransient<IRemoveCartItemCommandHandler, RemoveCartItemCommandHandler>();
        services.AddTransient<IGetCartQueryHandler, GetCartQueryHandler>();

        // DI Cart Events Handlers

        // DI Cart Facade
        services.AddTransient<ICartFacade, CartFacade>();

        return services;
    }
}