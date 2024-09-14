namespace ShopLand.Application.Account.Queries.GetUser.Response;

public sealed record GetUserQueryResponse
(
    Guid UserId,
    string FullName,
    string Email,
    List<Guid> Roles
) : IResponse;

public static class Extensions
{
    public static GetUserQueryResponse AsResponse(this User user)
        => new(user.Id, user.FullName.ToString(), user.Email, user.UsedInRoles.Select(s => s.Role).ToList());
}