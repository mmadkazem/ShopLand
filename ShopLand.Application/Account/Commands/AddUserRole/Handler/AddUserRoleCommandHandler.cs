namespace ShopLand.Application.Account.Commands.AddUserRole.Handler;
public class AddUserRoleCommandHandler(IUnitOfWork uow) : IAddUserRoleCommandHandler
{
    private readonly IUnitOfWork _uow = uow;

    public async Task HandelAsync(AddUserRoleCommandRequest request, CancellationToken token = default)
    {
        var user = await _uow.Users.FindAsync(request.id, token)
            ?? throw new UserNotFoundException();

        var role = await _uow.Roles.FindAsyncByName(request.roleName, token)
            ?? throw new RoleNotFoundException();

        user.AddRole(role.Id);

        await _uow.SaveAsync(token);
    }
}