namespace ShopLand.Application.Account.Commands.CreateRole.Handler;

public interface ICreateRoleCommandHandler
{
    Task HandelAsync(CreateRoleCommandRequest request, CancellationToken token = default);
}
