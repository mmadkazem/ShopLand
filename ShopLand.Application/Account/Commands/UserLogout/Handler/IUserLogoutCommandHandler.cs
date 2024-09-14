namespace ShopLand.Application.Account.Commands.UserLogout.Handler;

public interface IUserLogoutCommandHandler
{
    Task HandelAsync(UserLogoutCommandRequest request, CancellationToken token = default);
}
