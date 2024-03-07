namespace ShopLand.Application.Account.Queries.GetAllRole.Response;

public record GetAllRoleQueryResponse(Guid Id, string Name);

public static class Extensions
{
    internal static GetAllRoleQueryResponse AsResponse(this Role role)
        => new(role.Id, role.Name);
}