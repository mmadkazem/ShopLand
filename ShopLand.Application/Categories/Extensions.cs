using ShopLand.Application.Categories.Queries.GetAllCategory.Handler;
using ShopLand.Application.Categories.Queries.GetCategory.Handler;

namespace ShopLand.Application.Categories;

public static class Extensions
{
    public static IServiceCollection AddCategory(this IServiceCollection services)
    {
        // DI Category Commands and Queries
        services.AddTransient<ICreateCategoryCommandHandler, CreateCategoryCommandHandler>();
        services.AddTransient<IUpdateCategoryCommandHandler, UpdateCategoryCommandHandler>();
        services.AddTransient<IRemoveCategoryCommandHandler, RemoveCategoryCommandHandler>();
        services.AddTransient<IGetAllCategoryQueryHandler, GetAllCategoryQueryHandler>();
        services.AddTransient<IGetCategoryQueryHandler, GetCategoryQueryHandler>();

        // DI Category Events
        services.AddTransient<IRemovedCategoryEventHandler, RemovedCategoryEventHandler>();

        // DI Category Facade
        services.AddTransient<ICategoryFacade, CategoryFacade>();

        return services;
    }
}