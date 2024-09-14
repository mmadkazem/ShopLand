namespace ShopLand.Application.Account.Commands.RemoveRole.Handler;

public interface IRemoveRoleCommandHandler
{
    Task HandelAsync(RemoveRoleCommandRequest request, CancellationToken token = default);
}