namespace ShopLand.Infrastructure.Services.JwtToken;

public sealed class AppOptions
{
    public BearerTokensOption BearerTokensOption { get; set; }
    public RefreshTokenOption RefreshTokenOption { get; set; }
}
public sealed class BearerTokensOption
{
    public string Key { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public int AccessTokenExpirationMinutes { get; set; }
}

public sealed class RefreshTokenOption
{
    public string Key { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public int RefreshTokenExpirationMinutes { get; set; }
}