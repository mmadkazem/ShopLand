namespace ShopLand.Application.Account.Commands.UserLogout.Request;


public readonly record struct UserLogoutCommandRequest(Guid UserId)
{
    public static implicit operator UserLogoutCommandRequest(Guid request)
        => new(request);
};