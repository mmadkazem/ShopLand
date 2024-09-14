namespace ShopLand.Application.Account.Commands.CreateRole.Handler;

public interface ICreateRoleCommandHandler
{
    Task HandelAsync(CreateRoleCommandRequest request, CancellationToken token = default);
}
public class CreateRoleCommandHandler(IUnitOfWork uow, IRoleFactories roleFactories) : ICreateRoleCommandHandler
{
    private readonly IUnitOfWork _uow = uow;
    private readonly IRoleFactories _roleFactories = roleFactories;

    public async Task HandelAsync(CreateRoleCommandRequest request, CancellationToken token = default)
    {
        var result = await _uow.Roles.Any(request.RoleName, token);
        if (!result)
        {
            throw new RoleAlreadyExistsException();
        }
        var role = _roleFactories.Create(request.RoleName);

        _uow.Roles.Add(role);
        await _uow.SaveAsync(token);

    }
}