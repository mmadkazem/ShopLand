namespace ShopLand.Application.Account.Commands.RemoveUserRole.Handler;

public interface IRemoveUserRoleCommandHandler
{
    Task HandelAsync(RemoveUserRoleCommandRequest request);
}

public class RemoveUserRoleCommandHandler(IUnitOfWork uow)
    : IRemoveUserRoleCommandHandler
{
    private readonly IUnitOfWork _uow = uow;

    public async Task HandelAsync(RemoveUserRoleCommandRequest request)
    {
        var user = await _uow.Users.FindAsync(request.UserId);
        if (user is null)
        {
            throw new UserNotFoundException();
        }

        user.RemoveRole(request.RoleId);
        await _uow.SaveAsync();
    }
}