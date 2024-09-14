namespace ShopLand.Application.Account.Commands.CreateRole.Handler;

public sealed class CreateRoleCommandHandler(IUnitOfWork uow, IRoleFactories roleFactories)
    : ICreateRoleCommandHandler
{
    private readonly IUnitOfWork _uow = uow;
    private readonly IRoleFactories _roleFactories = roleFactories;

    public async Task HandelAsync(CreateRoleCommandRequest request, CancellationToken token = default)
    {
        if (!await _uow.Roles.Any(request.RoleName, token))
        {
            throw new RoleAlreadyExistsException();
        }
        var role = _roleFactories.Create(request.RoleName);

        _uow.Roles.Add(role);
        await _uow.SaveChangeAsync(token);

    }
}