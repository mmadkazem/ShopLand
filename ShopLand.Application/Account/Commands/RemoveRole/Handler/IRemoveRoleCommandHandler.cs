namespace ShopLand.Application.Account.Commands.RemoveRole.Handler;

public interface IRemoveRoleCommandHandler
{
    Task HandelAsync(RemoveRoleCommandRequest request);
}

public class RemoveRoleCommandHandler : IRemoveRoleCommandHandler
{
    private readonly IUnitOfWork _uow;
    private readonly IRemovedRoleEventHandler _removedRoleEvent;
    public RemoveRoleCommandHandler(IUnitOfWork uow,
        IRemovedRoleEventHandler removedRoleEvent)
    {
        _uow = uow;
        _removedRoleEvent = removedRoleEvent;
    }

    public async Task HandelAsync(RemoveRoleCommandRequest request)
    {
        var role = await _uow.Roles.FindAsync(request.RoleId);

        if (role is null)
        {
            throw new RoleNotFoundException();
        }

        _uow.Roles.Remove(role);
        await _uow.SaveAsync();
        await _removedRoleEvent.HandelAsync(role);
    }
}