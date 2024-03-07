namespace ShopLand.Application.Account.Queries.GetUser.Request;


public record GetUserQueryRequest(Guid UserId)
{
    public static implicit operator GetUserQueryRequest(Guid UserId)
        => new(UserId);
};