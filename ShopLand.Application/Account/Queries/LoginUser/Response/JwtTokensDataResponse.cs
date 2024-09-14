namespace ShopLand.Application.Account.Queries.LoginUser.Response;

public readonly record struct JwtTokensData
(
    string AccessToken, DateTimeOffset AccessTokenExpireTime,
    string RefreshToken, string RefreshTokenSerial, DateTimeOffset RefreshTokenExpireTime
);

public readonly record struct JwtTokensDataResponse(string AccessToken, string RefreshToken);