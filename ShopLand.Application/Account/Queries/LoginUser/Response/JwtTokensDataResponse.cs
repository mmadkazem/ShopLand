namespace ShopLand.Application.Account.Queries.LoginUser.Response;

public record JwtTokensData
    (string AccessToken, DateTimeOffset AccessTokenExpireTime,
     string RefreshToken, string RefreshTokenSerial, DateTimeOffset RefreshTokenExpireTime);

public record JwtTokensDataResponse(string AccessToken, string RefreshToken);