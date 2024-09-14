namespace ShopLand.Application.Account.Commands.ChangePassword.Handler;

public interface IChangePasswordCommandHandler
{
    Task HandelAsync(ChangePasswordCommandRequest request, CancellationToken token = default);
}
