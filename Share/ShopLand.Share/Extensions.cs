using ShopLand.Share.Exceptions;

namespace ShopLand.Share;

public static class Extensions
{
    public static IServiceCollection AddShared(this IServiceCollection services)
    {
        services.AddScoped<BadRequestExceptionMiddleware>();
        services.AddScoped<NotFoundExceptionMiddleware>();
        services.AddScoped<UnauthorizedExceptionMiddleware>();
        return services;
    }
    public static IApplicationBuilder UseShared(this IApplicationBuilder app)
    {
        app.UseMiddleware<BadRequestExceptionMiddleware>();
        app.UseMiddleware<NotFoundExceptionMiddleware>();
        app.UseMiddleware<UnauthorizedExceptionMiddleware>();
        return app;
    }
}