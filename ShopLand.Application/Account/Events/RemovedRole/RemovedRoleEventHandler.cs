namespace ShopLand.Application.Account.Events.RemovedRole;

public sealed class RemovedRoleEventHandler(IUnitOfWork uow)
    : IRemovedRoleEventHandler
{
    private readonly IUnitOfWork _uow = uow;

    public async Task HandelAsync(Guid roleId, CancellationToken token = default)
    {
        await _uow.Users.RemoveUserRoles(roleId, token);
    }
}