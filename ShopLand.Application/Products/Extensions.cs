using ShopLand.Application.Products.Commands.RemoveProductCategory.Handler;
using ShopLand.Application.Products.Commands.UpdateProductCategory.Handler;
using ShopLand.Application.Products.Events.ProductRemoved;

namespace ShopLand.Application.Products;

public static class Extensions
{
    internal static IServiceCollection AddProduct(this IServiceCollection services)
    {
        // DI Account Commands and Queries Handlers
        services.AddTransient<ICreateProductCommandHandler, CreateProductCommandHandler>();
        services.AddTransient<IRemoveProductCommandHandler, RemoveProductCommandHandler>();
        services.AddTransient<IGetAllProductQueryHandler, GetAllProductQueryHandler>();
        services.AddTransient<IGetProductQueryHandler, GetProductQueryHandler>();
        services.AddTransient<IUpdateProductCommandHandler, UpdateProductCommandHandler>();
        services.AddTransient<IAddProductCategoryCommandHandler, AddProductCategoryCommandHandler>();
        services.AddTransient<IUpdateProductCategoryCommandHandler, UpdateProductCategoryCommandHandler>();
        services.AddTransient<IRemoveProductCategoryCommandHandler, RemoveProductCategoryCommandHandler>();

        // DI Account Events Handlers
        services.AddTransient<IProductRemovedEventHandler, ProductRemovedEventHandler>();

        // DI Account Facade
        services.AddTransient<IProductFacade, ProductFacade>();

        return services;
    }
}