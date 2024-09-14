namespace ShopLand.Application.Account.Commands.RemoveRole.Handler;

public sealed class RemoveRoleCommandHandler(IUnitOfWork uow, IRemovedRoleEventHandler removedRoleEvent)
    : IRemoveRoleCommandHandler
{
    private readonly IUnitOfWork _uow = uow;
    private readonly IRemovedRoleEventHandler _removedRoleEvent = removedRoleEvent;

    public async Task HandelAsync(RemoveRoleCommandRequest request, CancellationToken token = default)
    {
        var role = await _uow.Roles.FindAsync(request.RoleId, token)
            ?? throw new RoleNotFoundException();

        _uow.Roles.Remove(role);
        await _uow.SaveChangeAsync(token);
        await _removedRoleEvent.HandelAsync(role.Id, token);
    }
}