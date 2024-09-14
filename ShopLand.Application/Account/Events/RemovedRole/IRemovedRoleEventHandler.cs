namespace ShopLand.Application.Account.Events.RemovedRole;

public interface IRemovedRoleEventHandler
{
    Task HandelAsync(Guid roleId, CancellationToken token = default);
}