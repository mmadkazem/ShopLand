namespace ShopLand.Application.Account.Events.RemovedRole;

public interface IRemovedRoleEventHandler
{
    Task HandelAsync(Guid roleId);
}
public class RemovedRoleEventHandler : IRemovedRoleEventHandler
{
    private readonly IUnitOfWork _uow;
    public RemovedRoleEventHandler(IUnitOfWork uow)
        => _uow = uow;

    public async Task HandelAsync(Guid roleId)
    {
        var userRoles = await _uow.Users.FindAsyncUserRole(roleId);
        _uow.Users.RemoveUserRoles(userRoles);
        await _uow.SaveAsync();
    }
}