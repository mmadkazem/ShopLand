namespace ShopLand.Application.Account.Commands.AddUserRole.Handler;
public class AddUserRoleCommandHandler : IAddUserRoleCommandHandler
{
    private readonly IUnitOfWork _uow;

    public AddUserRoleCommandHandler(IUnitOfWork uow)
        => _uow = uow;

    public async Task HandelAsync(AddUserRoleCommandRequest request)
    {
        var user = await _uow.Users.FindAsync(request.id);
        if (user is null)
        {
            throw new UserNotFoundException();
        }

        var role = await _uow.Roles.FindAsyncByName(request.roleName);
        if (role is null)
        {
            throw new RoleNotFoundException();
        }

        user.AddRole(role.Id);

        await _uow.SaveAsync();
    }
}