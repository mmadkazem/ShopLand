namespace ShopLand.Application.Account;

public static class Extensions
{
    internal static IServiceCollection AddAccount(this IServiceCollection services)
    {
        // DI Account Commands and Queries Handlers
        services.AddTransient<IRegisterUserCommandHandler, RegisterUserCommandHandler>();
        services.AddTransient<ILoginUserQueryHandler, LoginUserQueryHandler>();
        services.AddTransient<IAddUserRoleCommandHandler, AddUserRoleCommandHandler>();
        services.AddTransient<IGetUserQueryHandler, GetUserQueryHandler>();
        services.AddTransient<IChangePasswordCommandHandler, ChangePasswordCommandHandler>();
        services.AddTransient<ICreateRoleCommandHandler, CreateRoleCommandHandler>();
        services.AddTransient<IRemoveRoleCommandHandler, RemoveRoleCommandHandler>();
        services.AddTransient<IRemoveUserRoleCommandHandler, RemoveUserRoleCommandHandler>();
        services.AddTransient<IGetAllRoleQueryHandler, GetAllRoleQueryHandler>();
        services.AddTransient<IUserLogoutCommandHandler, UserLogoutCommandHandler>();
        services.AddTransient<ILoginUserByRefreshTokenCommandHandler, LoginUserByRefreshTokenCommandHandler>();

        // DI Account Events Handlers
        services.AddTransient<IAddedUserEventHandler, AddedUserEventHandler>();
        services.AddTransient<IRemovedRoleEventHandler, RemovedRoleEventHandler>();

        // DI Account Facade
        services.AddTransient<IAccountFacade, AccountFacade>();

        return services;
    }
}