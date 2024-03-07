namespace ShopLand.Application.Account.Queries.GetUser.Response;

public record GetUserQueryResponse
    (Guid UserId, string FullName,string Email, IEnumerable<Guid> Roles);

public static class Extensions
{
    public static GetUserQueryResponse AsResponse(this User user)
    => new
        (
            user.Id, user.FullName.ToString(), user.Email,
            user.UsedInRoles.Select(u => u.Role).ToList()
        );
}