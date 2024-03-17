using ShopLand.Application.Carts;
using ShopLand.Application.Categories;
using ShopLand.Application.Order;
using ShopLand.Application.Products;
using ShopLand.Application.RequestPays;

namespace ShopLand.Application;

public static class Extensions
{
    public static IServiceCollection AddApplications(this IServiceCollection services)
    {
        services.AddAccount();
        services.AddProduct();
        services.AddCategory();
        services.AddCart();
        services.AddRequestPay();
        services.AddOrder();

        return services;
    }
}