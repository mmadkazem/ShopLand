namespace ShopLand.Domain.Account.Users.ValueObject;


public record UserToken
{
    public UserToken(string accessTokenHash, DateTimeOffset accessTokenExpiresDateTime,
        string refreshTokenIdHash, string refreshTokenIdSerial,
        DateTimeOffset refreshTokenExpiresDateTime, UserId userId)
    {
        AccessTokenHash = accessTokenHash;
        AccessTokenExpiresDateTime = accessTokenExpiresDateTime;
        RefreshTokenIdHash = refreshTokenIdHash;
        RefreshTokenIdSerial = refreshTokenIdSerial;
        RefreshTokenExpiresDateTime = refreshTokenExpiresDateTime;
        UserId = userId;
    }

    public static UserToken Create(string accessTokenHash, DateTimeOffset accessTokenExpiresDateTime,
        string refreshTokenIdHash, string refreshTokenIdSerial,
        DateTimeOffset refreshTokenExpiresDateTime, UserId userId)
            => new(SecurityService.GetSha256Hash(accessTokenHash), accessTokenExpiresDateTime,
                SecurityService.GetSha256Hash(refreshTokenIdHash), refreshTokenIdSerial,
                refreshTokenExpiresDateTime, userId);

    public string AccessTokenHash { get; }

    public DateTimeOffset AccessTokenExpiresDateTime { get; }

    public string RefreshTokenIdHash { get; }

    public string RefreshTokenIdSerial { get; }

    public DateTimeOffset RefreshTokenExpiresDateTime { get; }

    public UserId UserId { get; }
    public bool IsExpire { get; private set; } = default;

    public void IsExpireToken()
    {
        IsExpire = true;
    }
}