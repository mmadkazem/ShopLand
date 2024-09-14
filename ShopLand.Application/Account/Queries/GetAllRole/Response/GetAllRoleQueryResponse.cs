namespace ShopLand.Application.Account.Queries.GetAllRole.Response;

public record GetAllRoleQueryResponse(Guid Id, string Name) : IResponse;

public static class Extensions
{
    public static GetAllRoleQueryResponse AsResponse(this Role role)
        => new(role.Id, role.Name);
}