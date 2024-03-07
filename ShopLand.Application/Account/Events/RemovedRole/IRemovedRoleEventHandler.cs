namespace ShopLand.Application.Account.Events.RemovedRole;

public interface IRemovedRoleEventHandler
{
    Task HandelAsync(Role role);
}
public class RemovedRoleEventHandler : IRemovedRoleEventHandler
{
    private readonly IUnitOfWork _uow;
    public RemovedRoleEventHandler(IUnitOfWork uow)
        => _uow = uow;

    public async Task HandelAsync(Role role)
    {
        await _uow.Users.RemoveRange(role.Id);
        await _uow.SaveAsync();
    }
}