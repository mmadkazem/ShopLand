namespace ShopLand.Application.Order;


public static class Extensions
{
    internal static IServiceCollection AddOrder(this IServiceCollection services)
    {
        // DI Account Commands and Queries Handlers
        services.AddTransient<ICreateOrderCommandHandler, CreateOrderCommandHandler>();
        services.AddTransient<IUpdateOrderStateCommandHandler, UpdateOrderStateCommandHandler>();
        services.AddTransient<IGetOrderByUserIdQueryHandler, GetOrderByUserIdQueryHandler>();
        services.AddTransient<IGetAllOrderQueryHandler, GetAllOrderQueryHandler>();

        // DI Account Events Handlers
        services.AddTransient<ICreatedOrderEventHandler, CreatedOrderEventHandler>();

        // DI Account Facade
        services.AddTransient<IOrderFacade, OrderFacade>();

        return services;
    }
}