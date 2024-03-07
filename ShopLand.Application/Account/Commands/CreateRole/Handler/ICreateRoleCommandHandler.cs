namespace ShopLand.Application.Account.Commands.CreateRole.Handler;

public interface ICreateRoleCommandHandler
{
    Task HandelAsync(CreateRoleCommandRequest request);
}
public class CreateRoleCommandHandler : ICreateRoleCommandHandler
{
    private readonly IUnitOfWork _uow;
    private readonly IRoleFactories _roleFactories;

    public CreateRoleCommandHandler(IUnitOfWork uow, IRoleFactories roleFactories)
    {
        _uow = uow;
        _roleFactories = roleFactories;
    }

    public async Task HandelAsync(CreateRoleCommandRequest request)
    {
        var result = await _uow.Roles.Any(request.RoleName);
        if (!result)
        {
            throw new RoleAlreadyExistsException();
        }
        var role = _roleFactories.Create(request.RoleName);

        _uow.Roles.Add(role);
        await _uow.SaveAsync();

    }
}