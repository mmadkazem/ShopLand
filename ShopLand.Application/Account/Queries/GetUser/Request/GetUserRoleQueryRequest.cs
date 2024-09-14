namespace ShopLand.Application.Account.Queries.GetUser.Request;


public readonly record struct GetUserQueryRequest(Guid UserId)
{
    public static implicit operator GetUserQueryRequest(Guid UserId)
        => new(UserId);
};