namespace ShopLand.Application.Account.Commands.LoginUserByRefreshToken.Request;


public readonly record struct LoginUserByRefreshTokenCommandRequest(Guid UserId, string RefreshTokenSerial);
