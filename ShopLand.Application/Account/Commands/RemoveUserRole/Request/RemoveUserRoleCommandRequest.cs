namespace ShopLand.Application.Account.Commands.RemoveUserRole.Request;

public record RemoveUserRoleCommandRequest(Guid UserId, Guid RoleId);