namespace ShopLand.Application.Account.Commands.AddUserRole.Request;


public readonly record struct AddUserRoleCommandRequest(Guid Id, string RoleName);