namespace ShopLand.Application.Account.Commands.RemoveUserRole.Handler;

public sealed class RemoveUserRoleCommandHandler(IUnitOfWork uow)
    : IRemoveUserRoleCommandHandler
{
    private readonly IUnitOfWork _uow = uow;

    public async Task HandelAsync(RemoveUserRoleCommandRequest request, CancellationToken token = default)
    {
        var user = await _uow.Users.FindAsync(request.UserId, token)
            ?? throw new UserNotFoundException();

        user.RemoveRole(request.RoleId);
        await _uow.SaveChangeAsync(token);
    }
}