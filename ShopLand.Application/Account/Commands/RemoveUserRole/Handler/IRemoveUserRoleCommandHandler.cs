namespace ShopLand.Application.Account.Commands.RemoveUserRole.Handler;

public interface IRemoveUserRoleCommandHandler
{
    Task HandelAsync(RemoveUserRoleCommandRequest request, CancellationToken token = default);
}
