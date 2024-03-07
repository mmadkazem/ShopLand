using ShopLand.Application.Products;

namespace ShopLand.Application;

public static class Extensions
{
    public static IServiceCollection AddApplications(this IServiceCollection services)
    {
        services.AddAccount();
        services.AddProduct();

        return services;
    }
}