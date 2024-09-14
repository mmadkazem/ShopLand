namespace ShopLand.Application.Account.Commands.RemoveUserRole.Request;

public readonly record struct RemoveUserRoleCommandRequest(Guid UserId, Guid RoleId);