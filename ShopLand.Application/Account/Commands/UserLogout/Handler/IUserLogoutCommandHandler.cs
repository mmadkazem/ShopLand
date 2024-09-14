namespace ShopLand.Application.Account.Commands.UserLogout.Handler;

public interface IUserLogoutCommandHandler
{
    Task HandelAsync(UserLogoutCommandRequest request, CancellationToken token = default);
}

public sealed class UserLogoutCommandHandler(IUnitOfWork uow) : IUserLogoutCommandHandler
{
    private readonly IUnitOfWork _uow = uow;

    public async Task HandelAsync(UserLogoutCommandRequest request, CancellationToken token = default)
    {
        var user = await _uow.Users.FindAsync(request.UserId, token)
            ?? throw new UserNotFoundException();

        user.Logout();
        await _uow.SaveAsync(token);
    }
}