namespace ShopLand.Application.Account.Commands.AddUserRole.Handler;

public interface IAddUserRoleCommandHandler
{
    Task HandelAsync(AddUserRoleCommandRequest request);
}
