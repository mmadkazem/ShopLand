using ShopLand.Domain.Orders.Factories;

namespace ShopLand.Infrastructure.Persistance;

internal static class Extensions
{
    internal static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration)
    {
        // DI Repositories
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IRoleRepository, RoleRepository>();
        services.AddTransient<IProductRepository, ProductRepository>();
        services.AddTransient<ICategoryRepository, CategoryRepository>();
        services.AddTransient<ICartRepository, CartRepository>();
        services.AddTransient<IOrderRepository, OrderRepository>();

        // DI Factories
        services.AddTransient<IUserFactories, UserFactories>();
        services.AddTransient<IRoleFactories, RoleFactories>();
        services.AddTransient<IProductFactory, ProductFactory>();
        services.AddTransient<ICategoryFactory, CategoryFactory>();
        services.AddTransient<ICartFactory, CartFactory>();
        services.AddTransient<IOrderFactory, OrderFactory>();

        // DI UnitOfWork
        services.AddTransient<IUnitOfWork, UnitOfWork>();

        var options = configuration.GetConnectionString("postgresServer");
        services.AddDbContext<DataBaseContext>(ctx =>
        ctx.UseNpgsql(options));

        return services;
    }
}