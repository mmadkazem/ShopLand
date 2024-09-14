namespace ShopLand.Application.Account.Commands.AddUserRole.Handler;
public sealed class AddUserRoleCommandHandler(IUnitOfWork uow)


    : IAddUserRoleCommandHandler
{
    private readonly IUnitOfWork _uow = uow;

    public async Task HandelAsync(AddUserRoleCommandRequest request, CancellationToken token = default)
    {
        var user = await _uow.Users.FindAsync(request.Id, token)
            ?? throw new UserNotFoundException();

        var role = await _uow.Roles.FindAsyncByName(request.RoleName, token)
            ?? throw new RoleNotFoundException();

        user.AddRole(role.Id);

        await _uow.SaveChangeAsync(token);
    }
}