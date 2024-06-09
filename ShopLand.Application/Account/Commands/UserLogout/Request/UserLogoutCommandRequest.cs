namespace ShopLand.Application.Account.Commands.UserLogout.Request;


public record UserLogoutCommandRequest(Guid UserId)
{
    public static implicit operator UserLogoutCommandRequest(Guid request)
        => new(request);
};